using NibulonBLL.Dto;

namespace NibulonBLL.Interfaces
{
    public interface IGrainElevatorArrivalsTableService
    {
        Task<GrainElevatorArrivalsTableDTO> GetGrainElevatorArrivalsTableByIdAsync(int id);
        Task AddOrUpdateGrainElevatorArrivalsTableAsync(GrainElevatorArrivalsTableDTO tableDto);
        Task DeleteGrainElevatorArrivalsTableAsync(int id);
    }
}
