using NibulonBLL.Dto;

namespace NibulonBLL.Interfaces
{
    public interface IGroupedDataTableService
    {
        Task<GroupedDataTableDTO> GetGroupedDataTableByIdAsync(int tableId);
        Task UpdateGroupedDataTableAsync(GroupedDataTableDTO tableDTO);
        Task DeleteGroupedDataTableAsync(GroupedDataTableDTO tableDTO);
    }
}
