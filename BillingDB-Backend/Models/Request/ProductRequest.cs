using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Models.Request
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ModelNumber { get; set; }

        [Required]
        public string HsnCode { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        public decimal GstRate { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
