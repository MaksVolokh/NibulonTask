using AutoMapper;
using NibulonBLL.Dto;
using NibulonBLL.Interfaces;
using NibulonDAL.Interfaces;


namespace NibulonBLL.NibulonBLL
{
    public class GroupedDataTableService : IGroupedDataTableService
    {
        private readonly IGroupedDataTableRepository _dataRepository;
        private readonly IMapper _mapper;

        public GroupedDataTableService(IMapper mapper, IGroupedDataTableRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }

        public async Task<GroupedDataTableDTO> GetGroupedDataTableByIdAsync(int tableId)
        {
            var table = await _dataRepository.GetGroupedDataTableByIdAsync(tableId);

            return _mapper.Map<GroupedDataTableDTO>(table);
        }

        public async Task UpdateGroupedDataTableAsync(GroupedDataTableDTO tableDTO)
        {
            var table = await _dataRepository.GetGroupedDataTableByIdAsync(tableDTO.Id);

            await _dataRepository.UpdateGroupedDataTableAsync(table);
        }

        public async Task DeleteGroupedDataTableAsync(GroupedDataTableDTO tableDTO)
        {
            var table = await _dataRepository.GetGroupedDataTableByIdAsync(tableDTO.Id);

            if (table != null)
            {
                await _dataRepository.DeleteGroupedDataTableAsync(table.Id);
            }
        }
    }
}
