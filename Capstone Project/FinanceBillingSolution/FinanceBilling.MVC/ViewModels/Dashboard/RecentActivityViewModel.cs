namespace FinanceBilling.MVC.ViewModels.Dashboard
{
    public class RecentActivityViewModel
    {
        public string Username { get; set; }
            = string.Empty;

        public string Action { get; set; }
            = string.Empty;

        public DateTime ChangedAt { get; set; }
    }
}
