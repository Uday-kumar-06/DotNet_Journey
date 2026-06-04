using System.ComponentModel.DataAnnotations;

namespace FinanceBilling.MVC.ViewModels.Payment
{
    public class CreatePaymentViewModel
    {
        [Required]
        public int InvoiceId { get; set; }

        [Required]
        public decimal AmountPaid { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
            = string.Empty;
    }
}
