using Microsoft.EntityFrameworkCore;
using NibulonDAL.Entities;

namespace NibulonDAL.Data
{
    public class DataContext : DbContext        
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Table1> Tables1 { get; set; }
        public DbSet<Table2> Tables2 { get; set; }
        public DbSet<Table3> Tables3 { get; set; }

    }
}
