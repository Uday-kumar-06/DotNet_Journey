using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Notification_System
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }

        public Order(string customerName, double amount)
        {
            OrderId = new Random().Next(1000, 9999);
            CustomerName = customerName;
            Amount = amount;
        }
    }
}
