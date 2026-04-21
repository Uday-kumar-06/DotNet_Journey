using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Delegates
{
    public delegate void MyDelegateMessage(string message);

    public delegate int MyDelegateCalculate(int a, int b);
    internal class EventDelegates
    {

        public event MyDelegateMessage MyDelegateMessageEvent;

        public event MyDelegateCalculate MyDelegateCalculate;
        public void DisplayMessage1(string message)
        {
            Console.WriteLine("Message1 :" + message);
        }

        public void DisplayMessage2(string message)
        {
            Console.WriteLine("Message2 :" + message);
        }

        public int DisplaySum(int a, int b)
        {
            return a + b;
        }

        public int DisplayProduct(int a, int b)
        {
            return a * b;
        }

        public int DisplayDifference(int a, int b)
        {
            return a - b;
        }

        public void TriggerMessageEvent(string message)
        {
            MyDelegateMessageEvent?.Invoke(message);
        }

        public void TriggerCalculateEvent(int a, int b)
        {
            if (MyDelegateCalculate != null)
            {
                foreach (MyDelegateCalculate del in MyDelegateCalculate.GetInvocationList())
                {
                    int result = del(a, b);
                    Console.WriteLine("Result: " + result);
                }
            }
        }
    }
}
