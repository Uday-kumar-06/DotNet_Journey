using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Notification_System.Services
{
    internal class SMSService
    {
        public void SMSSend(Order order)
        {
                Console.WriteLine("SMS notification sent to the customer.");
        }
    }
}
