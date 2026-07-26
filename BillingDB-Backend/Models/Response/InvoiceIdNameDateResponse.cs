namespace BillingDB_Backend.Models.Response
{
    public class InvoiceIdNameDateResponse
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
    }
}
