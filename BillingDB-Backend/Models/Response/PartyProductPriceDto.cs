namespace BillingDB_Backend.Models.Response
{
    public class PartyProductPriceDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ModelNumber { get; set; }

        public string? HsnCode { get; set; }

        public string? CategoryName { get; set; }

        public decimal BasePrice { get; set; }
        public decimal CustomPrice { get; set; }

        public decimal GstRate { get; set; }
    }
}
