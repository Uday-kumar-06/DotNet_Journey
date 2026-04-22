using System;
using System.Collections.Generic;
using System.Text;

namespace Scenario_Social_Media_Platform
{
    internal class UserService
    {
        //Program program = new Program();
        public void CreateUser()
        {
            
            Console.WriteLine("Enter username:");
            String username = Console.ReadLine();
            if (!string.IsNullOrEmpty(username) && !Program.userList.Contains(username))
            {
                Guid userId = Guid.NewGuid();
                Users newUser = new Users(userId, username);
                Program.users.Add(newUser);
                Program.userList.Add(username);
                newUser.Notifications.Enqueue("Welcome to the App, " + username + "!");
            }
        }

        public void Posts(Users user)
        {
            Console.WriteLine("Enter your post:");
            string postName = Console.ReadLine();
            user.Posts.Add(postName);
            Random rand = new Random();
            int number = rand.Next(1, 101);
            user.TrackLikes.Add(postName, number);
            user.RecentActions.Push(postName);
        }

        public void UndoAction(Users user)
        {
            if (user.RecentActions.Count > 0)
            {
                string lastAction = user.RecentActions.Pop();
                user.Posts.Remove(lastAction);
                user.TrackLikes.Remove(lastAction);
                Console.WriteLine("Last action undone: " + lastAction);
            }
            else
            {
                Console.WriteLine("No actions to undo.");
            }
        }


        public void ViewPosts(Users user)
        {
            Console.WriteLine("Your posts:");
            foreach (string post in user.Posts)
            {
                Console.WriteLine(post);
            }
        }
         public void ViewNotifications(Users user)
        {
            Console.WriteLine("Your notifications:");
            while (user.Notifications.Count > 0)
            {
                string notification = user.Notifications.Dequeue();
                Console.WriteLine(notification);
            }
        }

        public void TrackLikes(Users user)
        {
            Console.WriteLine("Your posts and their likes:");
            foreach (var post in user.TrackLikes)
            {
                Console.WriteLine($"Post: {post.Key}, Likes: {post.Value}");
            }
        }
    }
}
