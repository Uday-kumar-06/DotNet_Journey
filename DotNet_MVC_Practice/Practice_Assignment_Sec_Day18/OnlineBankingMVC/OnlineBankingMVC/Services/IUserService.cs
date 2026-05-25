namespace OnlineBankingMVC.Services
{
    public interface IUserService
    {
        bool ValidateUser(string username, string password);

        string GetUserRole(string username);
    }
}