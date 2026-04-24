using Banking_System_Exception_Handling;
using System;

class AmountEnteredException : Exception
{
    public AmountEnteredException(string message) : base(message)
    {
    }
}

class ExceededAmountException: Exception
{
    public ExceededAmountException(string message) : base(message)
    {
    }
}
class Program
{ 

    public void Deposit(Bank bank, double amount)
    {
        if (amount <= 0)
        {
            throw new AmountEnteredException("Deposit amount must be greater than zero.");
        }
        bank.TotalBalance += amount;
    }

    public void WithDraw(Bank bank, double Amount)
    {
        if (Amount > bank.TotalBalance)
        {
            throw new ExceededAmountException("Withdrawal amount exceeds the available balance.");
        }
        else if (Amount <= 0)
        {
            throw new AmountEnteredException("Withdrawal amount must be greater than zero.");
        }
        else if (bank.TotalBalance - Amount < 1000)
        {
            throw new ExceededAmountException("Withdrawal would reduce balance below minimum required.");
        }
        else { 
            bank.TotalBalance -= Amount;
        }
    }
    public static void Main(string[] agrs)
    {
        Bank bank = new Bank("MyBank", 1000);
        Console.WriteLine($"Bank Name: {bank.Name}, Total Balance: {bank.TotalBalance}");
        try
        {
            Program program = new Program();

            while (true)
            {
                Console.WriteLine("Enter 1 to Deposit, 2 to Withdraw, or 0 to Exit:");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }
                else if (input == "1")
                {
                    Console.WriteLine("Enter the amount to deposit:");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    program.Deposit(bank, amount);
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter the amount to withdraw:");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    program.WithDraw(bank, amount);
                }
                Console.WriteLine($"Updated Balance: {bank.TotalBalance}");
            }
        }
        catch(InvalidDataException){
             Console.WriteLine("Invalid data entered.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
