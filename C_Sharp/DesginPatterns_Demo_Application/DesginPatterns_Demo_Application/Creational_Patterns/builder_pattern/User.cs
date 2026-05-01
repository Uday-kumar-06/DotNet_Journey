using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Creational_Patterns.builder_pattern
{
    public class User
    {
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public int PhoneNumber { get; set; }

        public User(string firstName, string lastName, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
