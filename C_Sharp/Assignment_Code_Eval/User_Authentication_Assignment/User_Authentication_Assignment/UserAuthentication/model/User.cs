using System;
using System.Collections.Generic;
using System.Text;

namespace User_Authentication_Assignment.UserAuthentication.model
{
    public class User
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }

        public User(string username, string hashedPassword)
        {
            Username = username;
            HashedPassword = hashedPassword;
        }

        public void Register(User user,List<User> list)
        {
            list.Add(user);
        }

        public void Authenticate(string username, string password, List<User> list)
        {
            string hashedInput = UserCreation.HashPassword(password);

            foreach (var user in list)
            {
                if (user.Username == username && user.HashedPassword == hashedInput)
                {
                    Console.WriteLine("Authentication successful!");
                    return;
                }
            }
            Console.WriteLine("Authentication failed. Invalid username or password.");
        }
    }
}
