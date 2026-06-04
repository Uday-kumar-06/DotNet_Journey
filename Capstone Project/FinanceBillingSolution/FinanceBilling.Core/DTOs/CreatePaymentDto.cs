namespace FinanceBilling.Core.DTOs.Payment;

public class CreatePaymentDto
{
    public int InvoiceId { get; set; }

    public decimal AmountPaid { get; set; }

    public string PaymentMethod { get; set; } = string.Empty;
}