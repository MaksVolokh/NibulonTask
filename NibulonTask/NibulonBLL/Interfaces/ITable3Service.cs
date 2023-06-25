using NibulonBLL.Dto;

namespace NibulonBLL.Interfaces
{
    public interface ITable3Service
    {
        Task<Table3DTO> GetTable3ByDateAsync(DateTime date);
        Task UpdateTable3Async(DateTime date);
    }
}
