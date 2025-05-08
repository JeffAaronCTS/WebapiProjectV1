namespace WebapiProject.Models
{
    public class SalesReport
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public string Category { get; set; }
        public int TotalQuantitySold { get; set; }


        public decimal TotalSalesAmount { get; set; }
    }
}