using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NibulonDAL.Data;
using NibulonDAL.Entities;
using NibulonDAL.Interfaces;
using System.Data.Entity;

namespace NibulonDAL.Repositories
{
    public class GroupedDataTableRepository : IGroupedDataTableRepository
    {
        private readonly DataContext _context;
        public GroupedDataTableRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<GroupedDataTable> GetGroupedDataTableByIdAsync(int tableId)
        {
            return await _context.GroupedDataTables.FirstOrDefaultAsync(t => t.Id == tableId);
        }

        public async Task UpdateGroupedDataTableAsync(GroupedDataTable table)
        {
            _context.GroupedDataTables.Update(table);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupedDataTableAsync(int tableId)
        {
            var table = await _context.GroupedDataTables.FindAsync(tableId);

            if (table != null)
            {
                _context.GroupedDataTables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}
