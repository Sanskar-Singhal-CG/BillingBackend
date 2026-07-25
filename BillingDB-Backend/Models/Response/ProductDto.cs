namespace BillingDB_Backend.Models.Response
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string ModelNumber { get; set; } = null!;

        public string HsnCode { get; set; } = null!;

        public decimal BasePrice { get; set; }

        public decimal GstRate { get; set; }

        public CategoryDto? Category { get; set; }
    }
}
