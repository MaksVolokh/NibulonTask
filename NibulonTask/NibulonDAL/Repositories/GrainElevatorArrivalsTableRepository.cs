using NibulonDAL.Data;
using NibulonDAL.Entities;
using NibulonDAL.Interfaces;

namespace NibulonDAL.Repositories
{
    public class GrainElevatorArrivalsTableRepository : IGrainElevatorArrivalsTableRepository
    {
        private readonly DataContext _context;
        public GrainElevatorArrivalsTableRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<GrainElevatorArrivalsTable>? GetGrainElevatorArrivalsTableByIdAsync(int id)
        {
            return await _context.GrainElevatorArrivalsTables.FindAsync(id);
        }

        public async Task AddOrUpdateGrainElevatorArrivalsTableAsync(GrainElevatorArrivalsTable table)
        {
            if (table.Id == 0)
            {
                await _context.GrainElevatorArrivalsTables.AddAsync(table);
            }
            else
            {
                _context.GrainElevatorArrivalsTables.Update(table);
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteGrainElevatorArrivalsTableAsync(GrainElevatorArrivalsTable table)
        {
            _context.GrainElevatorArrivalsTables.Remove(table);

            await _context.SaveChangesAsync();
        }
    }
}
