using System;
using System.Collections.Generic;

namespace Scenario_Social_Media_Platform
{
    internal class Users
    {
        public Guid UserId { get; private set; }
        public string Username { get; set; }
        public List<string> Posts { get; set; }
        public Dictionary<string, int> TrackLikes { get; set; }
        public Stack<string> RecentActions { get; set; }
        public Queue<string> Notifications { get; set; }
        public Users(Guid userId, string username)
        {
            UserId = userId;
            Username = username;
            Posts = new List<string>();
            TrackLikes = new Dictionary<string, int>();
            RecentActions = new Stack<string>();
            Notifications = new Queue<string>();
        }
    }
}