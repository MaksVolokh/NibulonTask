using NibulonBLL.Dto;

namespace NibulonBLL.Interfaces
{
    public interface ITable1Service
    {
        Table1DTO GetTable1ById(int id);
        void AddOrUpdateTable1(Table1DTO table1Dto);
        void DeleteTable1(int id);
    }
}
