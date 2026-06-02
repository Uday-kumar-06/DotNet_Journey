using System.ComponentModel.DataAnnotations;

namespace FinanceBilling.Core.Models;

public class Invoice
{
    [Key]
    public int InvoiceId { get; set; }

    [Required]
    [StringLength(100)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    public DateTime InvoiceDate { get; set; }

    [Required]
    [Range(1, double.MaxValue)]
    public decimal TotalAmount { get; set; }

    [Required]
    public string Status { get; set; } = "Pending";

    public ICollection<Payment>? Payments { get; set; }
}