using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BillingDB_Backend.Entities
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [MaxLength(200)]
        public string? ProductName { get; set; }

        [MaxLength(100)]
        public string? ModelNumber { get; set; }

        [MaxLength(20)]
        public string? HsnCode { get; set; }

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal Rate { get; set; }

        [Precision(18, 2)]
        public decimal SubTotal { get; set; }

        [Precision(5, 2)]
        public decimal GstRate { get; set; }

        [Precision(18, 2)]
        public decimal GstAmount { get; set; }

        [Precision(18, 2)]
        public decimal Total { get; set; }
    }
}