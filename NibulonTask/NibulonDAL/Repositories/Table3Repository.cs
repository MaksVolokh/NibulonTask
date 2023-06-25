using NibulonDAL.Data;
using NibulonDAL.Entities;
using System.Data.Entity;

namespace NibulonDAL.Repositories
{
    public class Table3Repository
    {
        private readonly DataContext _context;
        public Table3Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<Table3> GetTable3ByDateAsync(DateTime date)
        {
            return await _context.Tables3.FirstOrDefaultAsync(t => t.Date == date);
        }

        public async Task UpdateTable3Async(Table3 table3)
        {
            _context.Tables3.Update(table3);
            await _context.SaveChangesAsync();
        }

    }
}
