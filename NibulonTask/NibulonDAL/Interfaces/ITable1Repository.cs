using NibulonDAL.Entities;

namespace NibulonDAL.Interfaces
{
    public interface ITable1Repository
    {
        Task<Table1> GetTable1ByIdAsync(int id);
        Task AddOrUpdateTable1Async(Table1 table1);
        Task DeleteTable1Async(Table1 table1);
    }
}
