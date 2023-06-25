using AutoMapper;
using NibulonBLL.Dto;
using NibulonBLL.Interfaces;
using NibulonDAL.Interfaces;


namespace NibulonBLL.NibulonBLL
{
    public class Table3Service : ITable3Service
    {
        private readonly ITable3Repository _table3Repository;
        private readonly IMapper _mapper;

        public Table3Service(ITable3Repository table3Repository, IMapper mapper)
        {
            _table3Repository = table3Repository;
            _mapper = mapper;
        }

        public async Task<Table3DTO> GetTable3ByDateAsync(DateTime date)
        {
            var table3 = await _table3Repository.GetTable3ByDateAsync(date);
            
            return _mapper.Map<Table3DTO>(table3);
        }

        public async Task UpdateTable3Async(DateTime date)
        {
            var table3 = await _table3Repository.GetTable3ByDateAsync(date);

            await _table3Repository.UpdateTable3Async(table3);
        }

    }
}
