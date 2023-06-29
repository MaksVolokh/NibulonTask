using System.ComponentModel.DataAnnotations;

namespace NibulonBLL.Dto
{
    public class GroupedDataTableDTO
    {
        public int Id { get; set; }
        public int RecordNumber { get; set; }
        public DateTime Date { get; set; }
        public int DepartmentCode { get; set; }

        [Range(2000, int.MaxValue, ErrorMessage = "Harvest year should be between 2000 and the current year.")]
        public int HarvestYear
        {
            get { return _harvestYear; }
            set
            {
                int currentYear = DateTime.Now.Year;
                _harvestYear = Math.Min(value, currentYear);
            }
        }
        private int _harvestYear;
        public string Contractor { get; set; }
        public string Name { get; set; }
        public string UniqueContractNumber { get; set; }
        public string ItemCode { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price should have up to 2 decimal places.")]
        public decimal Price { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,4})?$", ErrorMessage = "Net quantity should have up to 4 decimal places.")]
        public decimal NetQuantity { get; set; }
        public string Direction { get; set; }

        [Range(11, 15, ErrorMessage = "Moisture should be between 11 and 15")]
        public decimal? Moisture { get; set; }
        public decimal? Impurity { get; set; }
        public string? Contamination { get; set; }
    }
}
