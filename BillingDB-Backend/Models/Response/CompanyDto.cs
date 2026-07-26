namespace BillingDB_Backend.Models.Response
{
    public class CompanyDto
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? GSTIN { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? BankName { get; set; }

        public string? BankAccount { get; set; }

        public string? BankIFSC { get; set; }

        public byte[]? SignatureFile { get; set; }

    }
}
