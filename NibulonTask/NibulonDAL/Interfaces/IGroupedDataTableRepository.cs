using NibulonDAL.Entities;

namespace NibulonDAL.Interfaces
{
    public interface IGroupedDataTableRepository
    {
        Task<GroupedDataTable> GetGroupedDataTableByIdAsync(int tableId);
        Task UpdateGroupedDataTableAsync(GroupedDataTable dataTable);
        Task DeleteGroupedDataTableAsync(int id);
    }
}
