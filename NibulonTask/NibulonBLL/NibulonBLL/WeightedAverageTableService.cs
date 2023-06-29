using AutoMapper;
using NibulonBLL.Dto;
using NibulonBLL.Interfaces;
using NibulonDAL.Interfaces;


namespace NibulonBLL.NibulonBLL
{
    public class WeightedAverageTableService : IWeightedAverageTableService
    {
        private readonly IWeightedAverageTableRepository _weightedRepository;
        private readonly IMapper _mapper;

        public WeightedAverageTableService(IWeightedAverageTableRepository weightedRepository, IMapper mapper)
        {
            _weightedRepository = weightedRepository;
            _mapper = mapper;
        }

        public async Task<WeightedAverageTableDTO> GetWeightedAverageTableByIdAsync(int tableId)
        {
            var table = await _weightedRepository.GetWeightedAverageTableByIdAsync(tableId);
            
            return _mapper.Map<WeightedAverageTableDTO>(table);
        }

        public async Task UpdateWeightedAverageTableAsync(WeightedAverageTableDTO tableDTO)
        {
            var table = await _weightedRepository.GetWeightedAverageTableByIdAsync(tableDTO.Id);

            await _weightedRepository.UpdateWeightedAverageTableAsync(table);
        }

        public async Task DeleteWeightedAverageTableAsync(WeightedAverageTableDTO tableDTO)
        {
            var table = await _weightedRepository.GetWeightedAverageTableByIdAsync(tableDTO.Id);

            if (table != null)
            {
                await _weightedRepository.DeleteWeightedAverageTableAsync(table.Id);
            }
        }

    }
}
