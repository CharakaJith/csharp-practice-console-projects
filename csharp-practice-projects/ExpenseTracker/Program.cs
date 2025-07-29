using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpenseTracker tracker = new ExpenseTracker();
            tracker.LoadExpenses();

            bool runAgain = true;
            while (runAgain)
            {
                TrackerOperation operation = GetOperation();
                switch (operation)
                {
                    case TrackerOperation.Add:
                        tracker.AddNewExpense();

                        break;
                    case TrackerOperation.ViewAll:
                        tracker.ViewAll();

                        break;
                    case TrackerOperation.ViewMonthly:
                        tracker.ViewMonthlySummery();

                        break;

                    case TrackerOperation.SetMonthlyBudget:
                        tracker.SetBudget();

                        break;
                    case TrackerOperation.FilterByCategory:
                        tracker.FilterByCategory(); 
                        
                        break;
                    case TrackerOperation.Exit:
                        tracker.SaveExpenses();
                        runAgain = false;

                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("------- Your expenses are saved -------");
        }

        private static TrackerOperation GetOperation()
        {
            Console.WriteLine("\n------- Expense Tracker -------");
            Console.WriteLine("1 - Add new expense");
            Console.WriteLine("2 - View all expenses");
            Console.WriteLine("3 - View monthly summery");
            Console.WriteLine("4 - Set monthly budget");
            Console.WriteLine("5 - Filter by category");
            Console.WriteLine("x - Save and quit");

            while (true)
            {
                Console.Write("\nselect operation: ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        return TrackerOperation.Add;
                    case "2":
                        return TrackerOperation.ViewAll;
                    case "3":
                        return TrackerOperation.ViewMonthly;
                    case "4":
                        return TrackerOperation.SetMonthlyBudget;
                    case "5":
                        return TrackerOperation.FilterByCategory;
                    case "X":
                    case "x":
                        return TrackerOperation.Exit;
                    default:
                        Console.WriteLine("Please enter a valid operation!");
                        break;
                }
            }
        }
    }
}
