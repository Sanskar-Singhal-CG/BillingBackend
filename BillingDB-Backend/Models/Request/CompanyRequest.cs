using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Models.Request
{
    public class CompanyUpdateRequest
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? GSTIN { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? BankName { get; set; }

        public string? BankAccount { get; set; }

        public string? BankIFSC { get; set; }

        public IFormFile? SignatureFile { get; set; }
    }
}
