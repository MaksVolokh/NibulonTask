using AutoMapper;
using NibulonBLL.Dto;
using NibulonBLL.Interfaces;
using NibulonDAL.Entities;
using NibulonDAL.Interfaces;
using System.Reflection;

namespace NibulonBLL.NibulonBLL
{
    public class GrainElevatorArrivalsTableService : IGrainElevatorArrivalsTableService
    {
        private readonly IGrainElevatorArrivalsTableRepository _grainRepository;
        private readonly IGroupedDataTableRepository _dataRepository;
        private readonly IWeightedAverageTableRepository _weightedRepository;
        private readonly IMapper _mapper;

        public GrainElevatorArrivalsTableService(IGrainElevatorArrivalsTableRepository grainRepository, IGroupedDataTableRepository dataRepository, IWeightedAverageTableRepository weightedRepository, IMapper mapper)
        {
            _grainRepository = grainRepository;
            _dataRepository = dataRepository;
            _weightedRepository = weightedRepository;
            _mapper = mapper;
        }

        public async Task<GrainElevatorArrivalsTableDTO> GetGrainElevatorArrivalsTableByIdAsync(int id)
        {
            var table = await _grainRepository.GetGrainElevatorArrivalsTableByIdAsync(id);

            return _mapper.Map<GrainElevatorArrivalsTableDTO>(table);
        }

        public async Task AddOrUpdateGrainElevatorArrivalsTableAsync(GrainElevatorArrivalsTableDTO tableDto)
        {
            var table = _mapper.Map<GrainElevatorArrivalsTable>(tableDto);

            bool isNewRow = table.Id == 0;

            await _grainRepository.AddOrUpdateGrainElevatorArrivalsTableAsync(table);

            var date = table.Date;

            if (isNewRow)
            {
                await _dataRepository.UpdateGroupedDataTableAsync(new GroupedDataTable { Date = date });
                await _weightedRepository.UpdateWeightedAverageTableAsync(new WeightedAverageTable { Date = date });
            }
            else
            {
                var oldTable = await _grainRepository.GetGrainElevatorArrivalsTableByIdAsync(table.Id);

                if (oldTable != null)
                {
                    var changes = GetChanges(oldTable, table);

                    if (!string.IsNullOrEmpty(changes))
                    {
                        await _weightedRepository.UpdateWeightedAverageTableAsync(new WeightedAverageTable { Date = date, Changes = changes });
                    }
                }

                await _dataRepository.UpdateGroupedDataTableAsync(new GroupedDataTable { Date = date });
            }
        }

        private string GetChanges(GrainElevatorArrivalsTable oldTable, GrainElevatorArrivalsTable newTable)
        {
            List<string> changes = new List<string>();

            Type tableType = typeof(GrainElevatorArrivalsTable);
            PropertyInfo[] properties = tableType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object oldValue = property.GetValue(oldTable);
                object newValue = property.GetValue(newTable);

                if (!Equals(oldValue, newValue))
                {
                    string changeDescription = $"Property '{property.Name}' changed from '{oldValue}' to '{newValue}'.";
                    changes.Add(changeDescription);
                }    
            }

            return string.Join(", ", changes);
        }

        public async Task DeleteGrainElevatorArrivalsTableAsync(int id)
        {
            var table = await _grainRepository.GetGrainElevatorArrivalsTableByIdAsync(id);

            if (table != null)
            {
                await _grainRepository.DeleteGrainElevatorArrivalsTableAsync(table);

                await _dataRepository.DeleteGroupedDataTableAsync(table.Id);

                await _weightedRepository.DeleteWeightedAverageTableAsync(table.Id);
            }
        }
    }
}
