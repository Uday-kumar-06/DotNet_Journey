using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Notification_System.Services
{
    internal class LoggerService
    {
        public void LogOrder(Order order)
        {
            Console.WriteLine("Order logged in the system.");
        }
    }
}
