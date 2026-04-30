using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace User_Authentication_Assignment.UserAuthentication.model
{
    internal class UserCreation
    {
        public static void UserCreating()
        {
            List<User> list = new List<User>();

            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            string hashedPassword = HashPassword(password);

            User user = new User(username, hashedPassword);
            user.Register(user, list);

            Console.WriteLine("\nEnter username for authentication:");
            string authUsername = Console.ReadLine();

            Console.WriteLine("Enter password for authentication:");
            string authPassword = Console.ReadLine();

            user.Authenticate(authUsername, authPassword, list);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
