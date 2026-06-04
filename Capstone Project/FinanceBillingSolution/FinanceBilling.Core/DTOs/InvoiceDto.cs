namespace FinanceBilling.Core.DTOs.Invoice;

public class InvoiceDto
{
    public int InvoiceId { get; set; }

    public int ClientUserId { get; set; }

    public string ClientName { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime InvoiceDate { get; set; }

    public DateTime DueDate { get; set; }
}