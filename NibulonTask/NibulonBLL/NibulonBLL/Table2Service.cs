using AutoMapper;
using NibulonBLL.Dto;
using NibulonBLL.Interfaces;
using NibulonDAL.Interfaces;


namespace NibulonBLL.NibulonBLL
{
    public class Table2Service : ITable2Service
    {
        private readonly ITable2Repository _table2Repository;
        private readonly IMapper _mapper;

        public Table2Service(IMapper mapper, ITable2Repository table2Repository)
        {
            _table2Repository = table2Repository;
            _mapper = mapper;
        }

        public async Task<Table2DTO> GetTable2ByDateAsync(DateTime date)
        {
            var table2 = await _table2Repository.GetTable2ByDateAsync(date);

            return _mapper.Map<Table2DTO>(table2);
        }

        public async Task UpdateTable2Async(DateTime date)
        {
            var table2 = await _table2Repository.GetTable2ByDateAsync(date);

            await _table2Repository.UpdateTable2Async(table2);
        }
    }
}
