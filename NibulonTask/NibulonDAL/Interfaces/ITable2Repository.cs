using NibulonDAL.Entities;

namespace NibulonDAL.Interfaces
{
    public interface ITable2Repository
    {
        Task<Table2> GetTable2ByDateAsync(DateTime date);
        Task UpdateTable2Async(Table2 table2);
    }
}
