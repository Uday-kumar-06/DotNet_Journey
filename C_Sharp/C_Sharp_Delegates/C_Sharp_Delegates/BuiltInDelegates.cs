using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Delegates
{

    public delegate double DelegateAdd(int a, int b, double c);

    public delegate void DelegateAddDisplay(int a, int b, double c);

    public delegate bool DelegateIsLong(string str);
    internal class BuiltInDelegates
    {
        public double Add(int a, int b, double c)
        {
            return a + b + c;
        }

        public void AddDisplay(int a, int b, double c)
        {
            Console.WriteLine("The sum is: " + (a + b + c));
        }

        public bool IsLong(string str)
        {
            return str.Length > 5;
        }
    }
}
