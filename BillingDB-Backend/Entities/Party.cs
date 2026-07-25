using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Entities
{
    public class Party
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(20)]     
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be a 10-digit number.")]
        public string? Phone { get; set; }

        [MaxLength(500)]
        public string? BillingAddress { get; set; }

        [MaxLength(20)]
        public string? GSTIN { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string CreatedBy { get; set; } = "billingadmin";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string UpdatedBy { get; set; } = "billingadmin";
    }
}