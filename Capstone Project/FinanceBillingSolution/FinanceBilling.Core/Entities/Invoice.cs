using FinanceBilling.Core.Enums;

namespace FinanceBilling.Core.Entities;

public class Invoice
{
    public int InvoiceId { get; set; }

    public int ClientUserId { get; set; }

    public int CreatedByManagerId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public DateTime DueDate { get; set; }

    public decimal TotalAmount { get; set; }

    public InvoiceStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public User ClientUser { get; set; } = null!;

    public User CreatedByManager { get; set; } = null!;

    public ICollection<Payment> Payments { get; set; }
        = new List<Payment>();
}