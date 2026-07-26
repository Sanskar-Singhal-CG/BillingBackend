namespace BillingDB_Backend.Models.Response
{
    public class InvoiceDetailsResponse
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerGSTIN { get; set; }

        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyGSTIN { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyEmail { get; set; }
        public byte[]? SignatureFile { get; set; }
        public string? CompanyBankName { get; set; }
        public string? CompanyBankAccount { get; set; }
        public string? CompanyBankIFSC { get; set; }

        public decimal SubTotal { get; set; }
        public decimal TotalGst { get; set; }
        public decimal GrandTotal { get; set; }
        public List<InvoiceItemDetailsResponse> Items { get; set; } = new List<InvoiceItemDetailsResponse>();
    }
}
