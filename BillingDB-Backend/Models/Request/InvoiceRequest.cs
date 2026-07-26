using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Models.Request
{
    public class InvoiceRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<InvoiceItemRequest> Items { get; set; } = new List<InvoiceItemRequest>();

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal TotalGst { get; set; }

        [Required]
        public decimal GrandTotal { get; set; }
    }
}
