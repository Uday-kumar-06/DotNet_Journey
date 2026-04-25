using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption_Demo
{
    public class Student
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public Student(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
