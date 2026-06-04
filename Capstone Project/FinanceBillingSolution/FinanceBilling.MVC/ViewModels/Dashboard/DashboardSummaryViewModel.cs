namespace FinanceBilling.MVC.ViewModels.Dashboard
{
    public class DashboardSummaryViewModel
    {
        public decimal TotalBilled { get; set; }

        public decimal TotalCollected { get; set; }

        public decimal OutstandingAmount { get; set; }
        public int PaidInvoices { get; set; }

        public int PendingInvoices { get; set; }

        public int OverdueInvoices { get; set; }

        public int TotalInvoices { get; set; }

        public List<RecentActivityViewModel> RecentActivities{ get; set; }= new();
    }
}
