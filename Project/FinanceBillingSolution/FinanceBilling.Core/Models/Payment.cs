using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinanceBilling.Core.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal AmountPaid { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = string.Empty;
        public Invoice? Invoice { get; set; }
    }
}
