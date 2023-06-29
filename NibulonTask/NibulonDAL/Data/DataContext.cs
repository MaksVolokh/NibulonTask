using Microsoft.EntityFrameworkCore;
using NibulonDAL.Entities;

namespace NibulonDAL.Data
{
    public class DataContext : DbContext        
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<GrainElevatorArrivalsTable> GrainElevatorArrivalsTables { get; set; }
        public DbSet<GroupedDataTable> GroupedDataTables { get; set; }
        public DbSet<WeightedAverageTable> WeightedAverageTables { get; set; }

    }
}
