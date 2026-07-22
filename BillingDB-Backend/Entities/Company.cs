using System.ComponentModel.DataAnnotations;


namespace BillingDB_Backend.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(400)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? GSTIN { get; set; }
        [MaxLength(10)]
        public string? Phone { get; set; }

        [MaxLength(80)]
        public string? Email { get; set; }

        [MaxLength(200)]
        public string? BankName { get; set; }

        [MaxLength(100)]
        public string? BankAccount { get; set; }

        [MaxLength(50)]
        public string? BankIFSC { get; set; }

        [MaxLength(400)]
        public string? SignatureUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public string CreatedBy { get; set; } = "billingadmin";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public string UpdatedBy { get; set; } = "billingadmin";
    }
}
