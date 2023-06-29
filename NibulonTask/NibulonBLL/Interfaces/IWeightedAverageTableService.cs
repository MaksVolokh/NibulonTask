using NibulonBLL.Dto;

namespace NibulonBLL.Interfaces
{
    public interface IWeightedAverageTableService
    {
        Task<WeightedAverageTableDTO> GetWeightedAverageTableByIdAsync(int tableId);
        Task UpdateWeightedAverageTableAsync(WeightedAverageTableDTO tableDTO);
        Task DeleteWeightedAverageTableAsync(WeightedAverageTableDTO tableDTO);
    }
}
