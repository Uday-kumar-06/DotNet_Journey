using System;
using System.Collections.Generic;
using System.Text;
using Order_Notification_System;

namespace Order_Notification_System
{
    public delegate void OrderProcess(Order order);
    internal class OrderProcessor
    {
        public event OrderProcess OrderProcessEvent;

        public void OnOrderProcessed(Order order)
        {
            Console.WriteLine($"Order {order.OrderId} processed for {order.CustomerName} with amount {order.Amount}");
            OrderProcessEvent?.Invoke(order);
        }
    }
}
