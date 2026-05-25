namespace OnlineBankingMVC.Services
{
    public class UserService : IUserService
    {
        public bool ValidateUser(string username, string password)
        {
            return username == "admin" && password == "admin123";
        }

        public string GetUserRole(string username)
        {
            if (username == "admin")
            {
                return "Admin";
            }

            return "User";
        }
    }
}