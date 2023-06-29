using NibulonDAL.Entities;

namespace NibulonDAL.Interfaces
{
    public interface IWeightedAverageTableRepository
    {
        Task<WeightedAverageTable> GetWeightedAverageTableByIdAsync(int tableId);
        Task UpdateWeightedAverageTableAsync(WeightedAverageTable table);
        Task DeleteWeightedAverageTableAsync(int tableId);
    }
}
