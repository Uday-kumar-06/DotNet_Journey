namespace FinanceBilling.MVC.ViewModels.Payment
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }

        public int InvoiceId { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
