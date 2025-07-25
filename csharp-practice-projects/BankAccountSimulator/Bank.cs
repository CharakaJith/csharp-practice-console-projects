using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSimulator
{
    internal class Bank
    {
        private List<BankAccount> BankAccounts = new List<BankAccount>();

        public void CreateNewAccount()
        {
            Console.Write("\nAccount holders name: ");
            string name = Console.ReadLine();

            BankAccount account = new BankAccount(name);
            this.BankAccounts.Add(account);

            Console.WriteLine("Account created successfully.");
        }

        public void ListAccounts()
        {
            if (!this.BankAccounts.Any())
            {
                Console.WriteLine("\nNo accounts available.");
            }
            else
            {
                Console.WriteLine("\nAccounts: ");
                foreach (BankAccount account in this.BankAccounts)
                {
                    Console.WriteLine(account.ToString());
                }
            }
        }

        public void DepositMoney()
        {
            BankAccount account = FindAccountByNum();
            if (account == null)
            {
                return;
            }

            double amount = GetAmount("Amount to deposit");
            account.Deposit(amount);
        }

        public void WithdrawMoney()
        {
            BankAccount account = FindAccountByNum();
            if (account == null)
            {
                return;
            }

            double amount = GetAmount("Amount to withdraw");
            account.Withdraw(amount);
        }

        public void TransferMoney()
        {
            Console.WriteLine("Sender: ");
            BankAccount sender = FindAccountByNum();
            if (sender == null)
            {
                return;
            }

            Console.WriteLine("Reciever: ");
            BankAccount reciever = FindAccountByNum();
            if (reciever == null)
            {
                return;
            }

            if (sender.AccountNumber == reciever.AccountNumber)
            {
                Console.WriteLine("Invalid recipient.");
            }

            double amount = GetAmount("Amount to transfer");
            if (sender.Withdraw(amount))
            {
                reciever.Deposit(amount);
                Console.WriteLine("Transfer successful.");
            }
        }

        private BankAccount FindAccountByNum()
        {
            while (true)
            {
                Console.Write("\nEnter account number: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    BankAccount account = this.BankAccounts.FirstOrDefault(a => a.AccountNumber == number);
                    if (account != null)
                        return account;

                    Console.WriteLine("Account not found.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number!");
                }
            }
        }

        private double GetAmount(string message)
        {
            double amount;
            while (true)
            {
                Console.Write($"{message}: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out amount) && amount > 0)
                {
                    return amount;
                }
                   
                Console.WriteLine("Invalid amount.");
            }
        }
    }
}
