using System;

namespace BankingTransactionSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            TransactionSystem system = new TransactionSystem();
            system.CreateAccount("ACC1", 1000);
            system.CreateAccount("ACC2", 2000);

            Console.WriteLine();
            system.AddTransaction("T001", 500, "ACC1");  
            system.AddTransaction("T002", -200, "ACC1");  
            system.AddTransaction("T003", 300, "ACC2");   
            system.AddTransaction("T001", 100, "ACC1");   

            Console.WriteLine();
            system.ProcessTransactions("ACC1");
            Console.WriteLine();
            system.ShowBalance("ACC1");
            Console.WriteLine();
            system.Rollback("ACC1");
            Console.WriteLine();
            system.ShowBalance("ACC1");

            Console.WriteLine("\nProgram Finished.");
        }
    }
}