using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Delegates
{
    public delegate void MyDelegate(string message);

    public delegate int MyReturnTyprDelegate(int a);
    internal class MulticastDelegates
    {
        public void M1(string message)
        {
            Console.WriteLine("M1: " + message);
        }

        public void M2(string message)
        {
            Console.WriteLine("M2: " + message);
        }

        public int M3(int a)
        {
            return a * a;
        }
        public int M4(int a) {
            return a;
        }
    }
}
