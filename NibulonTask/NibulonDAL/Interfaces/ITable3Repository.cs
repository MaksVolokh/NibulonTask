using NibulonDAL.Entities;

namespace NibulonDAL.Interfaces
{
    public interface ITable3Repository
    {
        Task<Table3> GetTable3ByDateAsync(DateTime date);
        Task UpdateTable3(Table3 table3);
    }
}
