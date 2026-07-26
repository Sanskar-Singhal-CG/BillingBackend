namespace BillingDB_Backend.Models.Response
{
    public class InvoiceCreateResponse
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = null!;
    }
}
