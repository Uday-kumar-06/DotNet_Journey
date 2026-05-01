using DesginPatterns_Demo_Application.Behaviour_Pattern.observer_pattern;
using DesginPatterns_Demo_Application.Creational_Patterns;
using DesginPatterns_Demo_Application.Creational_Patterns.builder_pattern;
using DesginPatterns_Demo_Application.Creational_Patterns.factory_pattern;
using DesginPatterns_Demo_Application.Creational_Patterns.singleton_pattern;
using DesginPatterns_Demo_Application.Structural_Patterns.decorator_pattern;
using System;

namespace DesginPatterns_Demo_Application
{
    internal class Behaviour
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nSelect Design Pattern:");
                Console.WriteLine("1. Singleton");
                Console.WriteLine("2. Factory");
                Console.WriteLine("3. Builder");
                Console.WriteLine("4. Decorator");
                Console.WriteLine("5. Observer");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SingletonDemo();
                        break;

                    case "2":
                        FactoryDemo();
                        break;

                    case "3":
                        BuilderDemo();
                        break;

                    case "4":
                        DecoratorDemo();
                        break;

                    case "5":
                        ObserverDemo();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void SingletonDemo()
        {
            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();

            logger1.Log("Application started");
            logger2.Log("Processing data");
        }

        private void FactoryDemo()
        {
            Console.WriteLine("Enter payment method (phone / upi / card):");
            string input = Console.ReadLine();

            Payment payment = Factory.getFactoryInstance(input);

            if (payment != null)
            {
                payment.pay();
            }
            else
            {
                Console.WriteLine("Invalid payment type.");
            }
        }

        private void BuilderDemo()
        {
            User user = new UserBuilder()
                            .SetFirstName("Uday")
                            .SetLastName("Kumar")
                            .SetNumber(9876543210)
                            .Build();

            Console.WriteLine("User Details:");
            Console.WriteLine($"First Name: {user.FirstName}");
            Console.WriteLine($"Last Name: {user.LastName}");
            Console.WriteLine($"Phone: {user.PhoneNumber}");
        }

        private void DecoratorDemo()
        {
            IText text = new PlainText("Hello");
            text = new BoldDecorator(text);
            text = new ItalicDecorator(text);

            Console.WriteLine(text.Format());
        }

        private void ObserverDemo()
        {
            var publisher = new NewsPublisher();

            var mobile = new MobileApp();
            var email = new EmailService();

            mobile.Subscribe(publisher);
            email.Subscribe(publisher);

            publisher.PublishNews("Observer using Events!");
        }
    }
}