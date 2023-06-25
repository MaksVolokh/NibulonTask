using NibulonBLL.Dto;

namespace NibulonBLL.Interfaces
{
    public interface ITable2Service
    {
        Task<Table2DTO> GetTable2ByDateAsync(DateTime date);
        Task UpdateTable2Async(DateTime date);
    }
}
