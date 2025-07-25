using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSimulator
{
    internal class BankApp
    {
        public void Start()
        {
            Bank bank = new Bank();

            bool runAgain = true;
            while (runAgain)
            {
                BankOperations operation = SelectOperation();

                if (operation == BankOperations.Exit)
                {
                    runAgain = false;
                }
                else
                {
                    switch(operation)
                    {
                        case BankOperations.CreateAccount:
                            bank.CreateNewAccount();
                            break;
                        case BankOperations.ViewAllAccounts:
                            bank.ListAccounts();
                            break;
                        case BankOperations.Deposit:
                            bank.DepositMoney();
                            break;
                        case BankOperations.Withdraw:
                            bank.WithdrawMoney();
                            break;
                        case BankOperations.Transfer:
                            bank.TransferMoney();
                            break;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("------- Thank you for using our app -------");
        }

        private BankOperations SelectOperation()
        {
            Console.WriteLine("\n------- Bank Account Simulator -------");
            Console.WriteLine("\n1 - Create new account");
            Console.WriteLine("2 - View all accounts");
            Console.WriteLine("3 - Deposit money");
            Console.WriteLine("4 - Withdraw money");
            Console.WriteLine("5 - Transfer money");
            Console.WriteLine($"x - Exit app");

            while(true)
            {
                Console.Write("\nselect operation: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return BankOperations.CreateAccount;
                    case "2":
                        return BankOperations.ViewAllAccounts;
                    case "3":
                        return BankOperations.Deposit;
                    case "4":
                        return BankOperations.Withdraw;
                    case "5":
                        return BankOperations.Transfer;
                    case "X":
                    case "x":
                        return BankOperations.Exit;
                    default:
                        Console.WriteLine("Please enter a valid operation!");
                        break;
                }
            }
        }
    }
}
