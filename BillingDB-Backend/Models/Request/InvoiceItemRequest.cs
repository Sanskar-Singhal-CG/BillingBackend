using System.ComponentModel.DataAnnotations;

public class InvoiceItemRequest
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal Rate { get; set; }

    [Required]
    public decimal GstRate { get; set; }

    [Required]
    public decimal SubTotal { get; set; }

    [Required]
    public decimal GstAmount { get; set; }

    [Required]
    public decimal Total { get; set; }
}