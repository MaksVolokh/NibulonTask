using NibulonDAL.Data;
using NibulonDAL.Entities;
using NibulonDAL.Interfaces;
using System.Data.Entity;

namespace NibulonDAL.Repositories
{
    public class WeightedAverageTableRepository : IWeightedAverageTableRepository
    {
        private readonly DataContext _context;
        public WeightedAverageTableRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<WeightedAverageTable> GetWeightedAverageTableByIdAsync(int tableId)
        {
            return await _context.WeightedAverageTables.FirstOrDefaultAsync(t => t.Id == tableId);
        }

        public async Task UpdateWeightedAverageTableAsync(WeightedAverageTable table)
        {
            _context.WeightedAverageTables.Update(table);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteWeightedAverageTableAsync(int tableId)
        {
            var table = await _context.WeightedAverageTables.FindAsync(tableId);

            if (table != null)
            {
                _context.WeightedAverageTables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }

    }
}
