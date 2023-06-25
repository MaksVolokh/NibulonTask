
namespace NibulonDAL.Entities
{
    public class Table3
    {
        public int Id { get; set; }
        public string BatchNumber { get; set; }
        public DateTime Date { get; set; }
        public int DepartmentCode { get; set; }
        public int HarvestYear { get; set; }
        public string Contractor { get; set; }
        public string Name { get; set; }
        public string UniqueContractNumber { get; set; }
        public string ItemCode { get; set; }
        public decimal Price { get; set; }
        public decimal NetQuantity { get; set; }
        public string Direction { get; set; }
        public decimal Moisture { get; set; }
        public decimal Impurity { get; set; }
        public string Contamination { get; set; }
        public string Changes { get; set; }
    }
}
