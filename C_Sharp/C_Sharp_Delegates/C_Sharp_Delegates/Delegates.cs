using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Delegates
{
    public delegate int AddDelegate(int a, int b);

    
    internal class Delegates
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
            {
                return a - b;
        }
    }
}
