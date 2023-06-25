using NibulonDAL.Data;
using NibulonDAL.Entities;
using NibulonDAL.Interfaces;

namespace NibulonDAL.Repositories
{
    public class Table1Repository : ITable1Repository
    {
        private readonly DataContext _context;
        public Table1Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<Table1>? GetTable1ByIdAsync(int id)
        {
            return await _context.Tables1.FindAsync(id);
        }

        public async Task AddOrUpdateTable1Async(Table1 table1)
        {
            if (table1.Id == 0)
            {
                await _context.Tables1.AddAsync(table1);
            }

            else
            {
                _context.Tables1.Update(table1);
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteTable1Async(Table1 table1)
        {
            _context.Tables1.Remove(table1);
            await _context.SaveChangesAsync();
        }
    }
}
