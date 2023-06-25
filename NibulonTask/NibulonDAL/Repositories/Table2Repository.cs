using NibulonDAL.Data;
using NibulonDAL.Entities;
using NibulonDAL.Interfaces;
using System.Data.Entity;

namespace NibulonDAL.Repositories
{
    public class Table2Repository : ITable2Repository
    {
        private readonly DataContext _context;
        public Table2Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<Table2> GetTable2ByDateAsync(DateTime date)
        {
            return await _context.Tables2.FirstOrDefaultAsync(t => t.Date == date);
        }

        public async Task UpdateTable2Async(Table2 table2)
        {
            _context.Tables2.Update(table2);
            await _context.SaveChangesAsync();
        }
    }
}
