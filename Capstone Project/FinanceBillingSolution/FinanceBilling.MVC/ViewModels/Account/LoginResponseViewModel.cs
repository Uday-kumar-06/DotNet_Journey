namespace FinanceBilling.MVC.ViewModels.Account;

public class LoginResponseViewModel
{
    public string Token { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
}