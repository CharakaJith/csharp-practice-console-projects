using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSimulator
{
    internal class BankAccount
    {
        public int AccountNumber { get; set; }
        private string Name { get; set; }
        private double Balance { get; set; }

        public BankAccount(string name)
        {
            this.AccountNumber = GenerateAccountNumber();
            this.Name = name;
            this.Balance = 0.0;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            this.Balance += amount;
            Console.WriteLine($"Deposit amount: {amount} | Balance: {this.Balance}");
        }

        public bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdraw amount must be positive.");
                return false;
            }

            if (amount > this.Balance)
            {
                Console.WriteLine("Withdraw amount must not exceed the total amount.");
                return false;
            }

            this.Balance -= amount;
            Console.WriteLine($"Withdraw amount: {amount} | Balance: {this.Balance}");

            return true;
        }

        public override string ToString()
        {
            return $"[{this.AccountNumber}] {this.Name} -> $ {this.Balance}";
        }

        private int GenerateAccountNumber()
        {
            Random random = new Random();
            int accountNum = random.Next(10000, 100000);

            return accountNum;
        }
    }
}
