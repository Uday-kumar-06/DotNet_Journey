using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttribute
{
    [Custom("This the class",1)]
    public class Sample
    {
        [Custom("This is Property",2)]
        public string Name { get; set; }

        [Custom("This is method",3)]
        public static void Display()
        {
            Console.WriteLine("Hello World");
        }
    }
}
