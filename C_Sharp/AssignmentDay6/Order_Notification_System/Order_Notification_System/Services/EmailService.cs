using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Notification_System.Services
{
    internal class EmailService
    {
        public void EmailNotification(Order order)
        {
            Console.WriteLine("Email notification sent to the customer.");
        }
    }
}
