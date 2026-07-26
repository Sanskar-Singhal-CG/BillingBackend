using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string? Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string CreatedBy { get; set; } = "billingadmin";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string UpdatedBy { get; set; } = "billingadmin";
    }
}
