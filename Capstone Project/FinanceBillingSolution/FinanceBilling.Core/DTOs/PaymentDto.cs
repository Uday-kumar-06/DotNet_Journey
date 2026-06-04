namespace FinanceBilling.Core.DTOs.Payment;

public class PaymentDto
{
    public int PaymentId { get; set; }

    public int InvoiceId { get; set; }

    public decimal AmountPaid { get; set; }

    public DateTime PaymentDate { get; set; }
}