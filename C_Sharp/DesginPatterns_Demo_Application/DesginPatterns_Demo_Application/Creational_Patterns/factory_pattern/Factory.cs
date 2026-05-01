using DesginPatterns_Demo_Application.Creational_Patterns.factory_pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Creational_Patterns
{

    public class UPI: Payment
    {
        public void pay()
        {
            Console.WriteLine("Paid through UPI...");
        }
    }

    public class PhoneNumber : Payment
    {
        public void pay()
        {
            Console.WriteLine("Paid through phone number...");
        }
    }

    public class Card : Payment
    {
        public void pay()
        {
            Console.WriteLine("Paid through Card...");
        }
    }

     class Factory
    {
        public static Payment getFactoryInstance(string str) {
            if(str == "phone")
            {
                return new PhoneNumber();
            }
            else if(str == "upi"){ 
                return new UPI();
            }
            else if(str == "card")
            {
                return new Card();
            }
            else
            {
                Console.WriteLine("Error in correct input");
            }
            return null;
        }
    }
}
