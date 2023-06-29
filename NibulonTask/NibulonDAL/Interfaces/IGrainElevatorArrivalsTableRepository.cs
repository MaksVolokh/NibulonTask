using NibulonDAL.Entities;

namespace NibulonDAL.Interfaces
{
    public interface IGrainElevatorArrivalsTableRepository
    {
        Task<GrainElevatorArrivalsTable> GetGrainElevatorArrivalsTableByIdAsync(int id);
        Task AddOrUpdateGrainElevatorArrivalsTableAsync(GrainElevatorArrivalsTable table);
        Task DeleteGrainElevatorArrivalsTableAsync(GrainElevatorArrivalsTable table);
    }
}
