using System;
using System.Collections.Generic;
using Scenario_Social_Media_Platform;

class Program
{
    public static List<string> userList = new List<string>();
    public static List<Users> users = new List<Users>();
    public static UserService userService = new UserService();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Select User");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    userService.CreateUser();
                    break;

                case 2:
                    Users selectedUser = SelectUser();
                    if (selectedUser != null)
                    {
                        UserMenu(selectedUser);
                    }
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
    public static Users SelectUser()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("No users available.");
            return null;
        }

        Console.WriteLine("\nAvailable Users:");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i].Username}");
        }

        Console.Write("Select user number: ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        if (index >= 0 && index < users.Count)
        {
            return users[index];
        }

        Console.WriteLine("Invalid selection.");
        return null;
    }
    public static void UserMenu(Users user)
    {
        while (true)
        {
            Console.WriteLine($"Welcome {user.Username} ");
            Console.WriteLine("1. Create Post");
            Console.WriteLine("2. Undo Last Action");
            Console.WriteLine("3. View Posts");
            Console.WriteLine("4. View Notifications");
            Console.WriteLine("5. Track Likes");
            Console.WriteLine("6. Back");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    userService.Posts(user);
                    break;

                case 2:
                    userService.UndoAction(user);
                    break;

                case 3:
                    userService.ViewPosts(user);
                    break;

                case 4:
                    userService.ViewNotifications(user);
                    break;

                case 5:
                    userService.TrackLikes(user);
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}