using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Creational_Patterns.builder_pattern
{
    internal class UserBuilder
    {
        private User user = new User();
        public UserBuilder SetName(string name) {
            user.FirstName = name;
            return this;
        }


    }
}
