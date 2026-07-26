namespace BillingDB_Backend.Models.Response
{
    public class InvoiceItemDetailsResponse
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ModelNumber { get; set; }
        public string? HsnCode { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GstRate { get; set; }
        public decimal GstAmount { get; set; }
        public decimal Total { get; set; }
    }
}
