using System.ComponentModel.DataAnnotations;

namespace FinanceBilling.MVC.ViewModels.Invoice
{
    public class CreateInvoiceViewModel
    {
        [Required]
        public int ClientUserId { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}
