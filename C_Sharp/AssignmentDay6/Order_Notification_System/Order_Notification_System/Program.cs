using Order_Notification_System;
using Order_Notification_System.Services;
using System;
class Program
{
    public static void Main(string[] args)
    {
        Order order1 = new Order("uday", 100.0);
        Order order2 = new Order("john", 200.0);
        Order order3 = new Order("kumar", 150.0);
        Order order4 = new Order("babu", 250.0);

        OrderProcessor processor = new OrderProcessor();

        EmailService email = new EmailService();
        SMSService sms = new SMSService();
        LoggerService logger = new LoggerService();

        processor.OrderProcessEvent += email.EmailNotification;
        processor.OrderProcessEvent += sms.SMSSend;
        processor.OrderProcessEvent += logger.LogOrder;

        processor.OnOrderProcessed(order1);
        processor.OnOrderProcessed(order2);
        processor.OnOrderProcessed(order3);
        processor.OnOrderProcessed(order4);

    }
}
