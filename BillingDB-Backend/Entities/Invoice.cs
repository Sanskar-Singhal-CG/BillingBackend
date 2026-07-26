using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BillingDB_Backend.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string InvoiceNumber { get; set; } = null!;

        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }

        public Party? Customer { get; set; }

        [MaxLength(200)]
        public string? CustomerName { get; set; }

        [MaxLength(200)]
        public string? CustomerContactPerson { get; set; }

        [MaxLength(20)]
        public string? CustomerPhone { get; set; }

        [MaxLength(500)]
        public string? CustomerAddress { get; set; }

        [MaxLength(20)]
        public string? CustomerGSTIN { get; set; }

        [MaxLength(200)]
        public string? CompanyName { get; set; }

        [MaxLength(500)]
        public string? CompanyAddress { get; set; }

        [MaxLength(20)]
        public string? CompanyGSTIN { get; set; }

        [MaxLength(20)]
        public string? CompanyPhone { get; set; }

        [MaxLength(100)]
        public string? CompanyEmail { get; set; }

        [MaxLength(500)]
        public string? CompanySignatureUrl { get; set; }

        [MaxLength(200)]
        public string? CompanyBankName { get; set; }

        [MaxLength(50)]
        public string? CompanyBankAccount { get; set; }

        [MaxLength(20)]
        public string? CompanyBankIFSC { get; set; }

        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        [Precision(18, 2)]
        public decimal SubTotal { get; set; }

        [Precision(18, 2)]
        public decimal TotalGst { get; set; }

        [Precision(18, 2)]
        public decimal GrandTotal { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string CreatedBy { get; set; } = "billingadmin";

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string UpdatedBy { get; set; } = "billingadmin";
    }
}