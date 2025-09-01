namespace Office.Api.Entities;

public class Payment : BaseEntity
{
    public int RequestId { get; set; }
    public LegalRequest Request { get; set; } = null!;
    public int ClientId { get; set; }
    public User Client { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Status { get; set; } = "pending"; // pending, paid, failed, refunded
    public string? InvoiceNumber { get; set; }
    public string PaymentMethod { get; set; } = "card"; // card, paypal, bank_transfer
}
