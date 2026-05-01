using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Creational_Patterns.builder_pattern
{
    internal class UserBuilder
    {
        private User user = new User();
        public UserBuilder SetFirstName(string name) {
            user.FirstName = name;
            return this;
        }

        public UserBuilder SetLastName(string name)
        {
            user.LastName = name;
            return this;
        }

        public UserBuilder SetNumber(long number)
        {
            user.PhoneNumber = number;
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}
