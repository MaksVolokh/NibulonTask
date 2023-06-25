using NibulonDAL.Entities;

namespace NibulonDAL.Interfaces
{
    public interface ITable3Repository
    {
        Task<Table3> GetTable3ByDateAsync(DateTime date);
        Task UpdateTable3Async(Table3 table3);
    }
}
