using AutoMapper;
using NibulonBLL.Dto;
using NibulonBLL.Interfaces;
using NibulonDAL.Entities;
using NibulonDAL.Interfaces;


namespace NibulonBLL.NibulonBLL
{
    public class Table1Service : ITable1Service
    {
        private readonly ITable1Repository _table1Repository;
        private readonly ITable2Repository _table2Repository;
        private readonly ITable3Repository _table3Repository;
        private readonly IMapper _mapper;

        public Table1Service(ITable1Repository table1Repository, ITable2Repository table2Repository, ITable3Repository table3Repository, IMapper mapper)
        {
            _table1Repository = table1Repository;
            _table2Repository = table2Repository;
            _table3Repository = table3Repository;
            _mapper = mapper;
        }

        public async Task<Table1DTO> GetTable1ByIdAsync(int id)
        {
            var table1 = await _table1Repository.GetTable1ByIdAsync(id);

            return _mapper.Map<Table1DTO>(table1);
        }

        public async Task AddOrUpdateTable1Async(Table1DTO table1Dto)
        {
            var table1 = _mapper.Map<Table1>(table1Dto);

            await _table1Repository.AddOrUpdateTable1Async(table1);

            var date = table1.Date;
            await _table2Repository.UpdateTable2Async(new Table2 { Date = date });
            await _table3Repository.UpdateTable3Async(new Table3 { Date = date });
        }

        public async Task DeleteTable1Async(int id)
        {
            var table1 = await _table1Repository.GetTable1ByIdAsync(id);

            if (table1 != null)
            {
                await _table1Repository.DeleteTable1Async(table1);

                var date = table1.Date;
                await _table2Repository.UpdateTable2Async(new Table2 { Date = date });
                await _table3Repository.UpdateTable3Async(new Table3 { Date = date });
            }
        }
    }
}
