using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern_Assignment_day10.Factory
{
    internal class ConcreteClasses1: Interface1
    {
        public void Open()
        {
            Console.WriteLine("Concrete class1 is opened");
        }
    }

    internal class ConcreteClasses2 : Interface1
    {
        public void Open()
        {
            Console.WriteLine("Concrete class 2 is opened");
        }
    }
}
