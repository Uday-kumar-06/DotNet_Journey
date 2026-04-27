using System;
using System.Collections.Generic;
using Encryption_Demo;

class Program
{
    static Dictionary<string, string> userStore = new Dictionary<string, string>();

    public static void Main(string[] args)
    {
        var encryptor = new Basic_Encryption();
        var passwordChecker = new ComparingPassword();

        while (true)
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateAccount(encryptor);
                    break;

                case "2":
                    LoginUser(passwordChecker);
                    break;

                case "3":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }
    }

    static void CreateAccount(Basic_Encryption encryptor)
    {
        Console.Write("Choose a username: ");
        string username = Console.ReadLine();

        if (userStore.ContainsKey(username))
        {
            Console.WriteLine("This username is already taken.");
            return;
        }

        Console.Write("Choose a password: ");
        string password = Console.ReadLine();

        encryptor.BasicEncrypt(ref password);

        userStore[username] = password;

        Console.WriteLine("Account created successfully!");
    }

    static void LoginUser(ComparingPassword passwordChecker)
    {
        Console.WriteLine("Enter your username: ");
        string username = Console.ReadLine();

        if (!userStore.ContainsKey(username))
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        bool isCorrect = passwordChecker.ComparePassword(password, userStore[username]);

        if (isCorrect)
        {
            Console.WriteLine("Login successful!");
        }
        else
        {
            Console.WriteLine("Wrong password.");
        }
    }
}