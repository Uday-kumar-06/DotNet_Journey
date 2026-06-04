namespace FinanceBilling.MVC.ViewModels.User;

public class PendingUserViewModel
{
    public int UserId { get; set; }

    public string Username { get; set; }
        = string.Empty;

    public string Email { get; set; }
        = string.Empty;

    public bool IsApproved { get; set; }
}