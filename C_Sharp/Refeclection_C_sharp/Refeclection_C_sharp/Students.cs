using System;
using System.Collections.Generic;
using System.Text;

namespace Refeclection_C_sharp
{
    internal class Students
    {
        public string name { get; set; }
        public string section { get; set; }
        public int rollno { get; set; } 



        public Students(string name, string section, int rollno)
        {
            this.name = name;
            this.section = section;
            this.rollno = rollno;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {name}, Section: {section}, Roll No: {rollno}");
        }
    }
}
