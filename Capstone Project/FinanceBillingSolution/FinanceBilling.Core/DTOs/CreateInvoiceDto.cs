namespace FinanceBilling.Core.DTOs.Invoice;

public class CreateInvoiceDto
{
    public int ClientUserId { get; set; }

    public DateTime DueDate { get; set; }

    public decimal TotalAmount { get; set; }
}