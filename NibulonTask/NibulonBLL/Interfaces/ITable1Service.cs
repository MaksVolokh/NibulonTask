using NibulonBLL.Dto;

namespace NibulonBLL.Interfaces
{
    public interface ITable1Service
    {
        Task<Table1DTO> GetTable1ByIdAsync(int id);
        Task AddOrUpdateTable1Async(Table1DTO table1Dto);
        Task DeleteTable1Async(int id);
    }
}
