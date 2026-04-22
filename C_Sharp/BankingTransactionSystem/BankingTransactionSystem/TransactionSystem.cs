using System;
using System.Collections.Generic;
using System.Text;

namespace BankingTransactionSystem
{
    internal class TransactionSystem
    {
        private List<Transactions> transactionHistory = new List<Transactions>();
        private Dictionary<string, double> accountBalances = new Dictionary<string, double>();
        private Queue<Transactions> pendingTransactions = new Queue<Transactions>();
        private Stack<Transactions> rollbackStack = new Stack<Transactions>();
        private HashSet<string> transactionIds = new HashSet<string>();

        public void CreateAccount(string accountId, double initialBalance)
        {
            if (!accountBalances.ContainsKey(accountId))
            {
                accountBalances[accountId] = initialBalance;
                Console.WriteLine("Account created successfully.");
            }
            else
            {
                Console.WriteLine("Account already exists.");
            }
        }

        public void AddTransaction(string transactionId, double amount, string accountId)
        {
            if (transactionIds.Contains(transactionId))
            {
                Console.WriteLine($"Transaction ID {transactionId} already exists. Transaction rejected.");
                return;
            }
            double currentBalance = accountBalances.ContainsKey(accountId) ? accountBalances[accountId] : 0;
            double newBalance = currentBalance + amount;
            Transactions transaction = new Transactions
            {
                TransactionId = transactionId,
                Amount = amount,
                Balance = newBalance
            };
            pendingTransactions.Enqueue(transaction);
            transactionIds.Add(transactionId);
        }

        public void ProcessTransactions(string accountId)
        {
            while (pendingTransactions.Count > 0)
            {
                Transactions t = pendingTransactions.Dequeue();

                if (!accountBalances.ContainsKey(accountId))
                {
                    Console.WriteLine("Account not found.");
                    return;
                }

                accountBalances[accountId] += t.Amount;
                t.Balance = accountBalances[accountId];

                transactionHistory.Add(t);
                rollbackStack.Push(t);

                Console.WriteLine($"Processed: {t.TransactionId}, Balance: {t.Balance}");
            }
        }
        public void Rollback(string accountId)
        {
            if (rollbackStack.Count == 0)
            {
                Console.WriteLine("No transactions to rollback.");
                return;
            }

            Transactions last = rollbackStack.Pop();

            accountBalances[accountId] -= last.Amount;
            Console.WriteLine($"Rolled back: {last.TransactionId}");

            transactionHistory.Remove(last);
        }
        public void ShowBalance(string accountId)
        {
            if (accountBalances.ContainsKey(accountId))
            {
                Console.WriteLine($"Balance: {accountBalances[accountId]}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}
