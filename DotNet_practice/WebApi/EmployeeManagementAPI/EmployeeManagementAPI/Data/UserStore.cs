using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Data
{
    public static class UserStore
    {
        public static List<User> Users = new()
        {
            new User
            {
                UserId = 1,
                Username = "admin",
                Password = "Admin@123",
                Role = "Admin"
            },

            new User
            {
                UserId = 2,
                Username = "employee",
                Password = "Emp@123",
                Role = "Employee"
            }
        };
    }
}