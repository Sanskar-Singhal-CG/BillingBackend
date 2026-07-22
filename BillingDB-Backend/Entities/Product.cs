using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BillingDB_Backend.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? ModelNumber { get; set; }

        [MaxLength(20)]
        public string? HsnCode { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Precision(18, 2)]
        public decimal BasePrice { get; set; }

        [Precision(5, 2)]
        public decimal GstRate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string CreatedBy { get; set; } = "billingadmin";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string UpdatedBy { get; set; } = "billingadmin";
    }
}