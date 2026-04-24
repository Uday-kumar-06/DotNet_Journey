using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_System_Exception_Handling
{
    internal class Bank
    {
        public string Name { get; set; }
        public double TotalBalance { get; set; }

        public Bank(string name, double totalBalance) { 
            Name = name;
            TotalBalance = totalBalance;
        }
    }
}
