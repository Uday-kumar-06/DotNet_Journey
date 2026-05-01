using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Behaviour_Pattern.observer_pattern
{
    public class MobileApp
    {
        public void Subscribe(NewsPublisher publisher)
        {
            publisher.OnNewsPublished += Update;
        }

        private void Update(string news)
        {
            Console.WriteLine($"Mobile App: {news}");
        }
    }

    public class EmailService
    {
        public void Subscribe(NewsPublisher publisher)
        {
            publisher.OnNewsPublished += SendEmail;
        }

        private void SendEmail(string news)
        {
            Console.WriteLine($"Email: {news}");
        }
    }
}
