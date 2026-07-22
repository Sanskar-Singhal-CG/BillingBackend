using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BillingDB_Backend.Entities
{
    public class PartyProductPrice
    {
        [Key]
        public int Id { get; set; }

        public int PartyId { get; set; }

        public Party? Party { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        [Precision(18, 2)]
        public decimal CustomPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [MaxLength(200)]
        public string CreatedBy { get; set; } = "billingadmin";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string UpdatedBy { get; set; } = "billingadmin";
    }
}
