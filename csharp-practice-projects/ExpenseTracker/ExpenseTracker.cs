using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    internal class ExpenseTracker
    {
        private List<Expense> expenses = new List<Expense>();
        private const string FilePath = "expenses.json";
        private decimal monthlyBudget = 0;

        public void AddNewExpense()
        {
            Console.Write("\ncategory: ");
            string category = Console.ReadLine();

            if (string.IsNullOrEmpty(category))
            {
                Console.WriteLine("Category cannot be empty!");
                return;
            }

            Console.Write("amount: ");
            string amountStr = Console.ReadLine();

            if (!decimal.TryParse(amountStr, out var amount))
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            Console.Write("note (optional): ");
            string note = Console.ReadLine();

            this.expenses.Add(new Expense
            {
                Category = category,
                Amount = amount,
                Note = note,
                Date = DateTime.Now,
            });
            Console.WriteLine("New expense created.");
        }

        public void ViewAll()
        {
            if (!this.expenses.Any())
            {
                Console.WriteLine("No expenses available!");
                return;
            }

            Console.WriteLine();
            foreach (Expense exp in this.expenses)
            {
                Console.WriteLine(exp.ToString());
            }
        }

        public void ViewMonthlySummery()
        {
            if (!this.expenses.Any())
            {
                Console.WriteLine("No expenses available!");
                return;
            }

            var now = DateTime.Now;
            var monthlyExpenses = this.expenses
                .Where(e => e.Date.Month == now.Month && e.Date.Year == now.Year)
                .ToList();

            var total = monthlyExpenses.Sum(e => e.Amount);
            Console.WriteLine($"\nTotal expenses for {now:MMMM yyyy}: ${total}");

            if (this.monthlyBudget > 0)
            {
                Console.WriteLine($"Monthly Budget: ${this.monthlyBudget}");
                if (total > this.monthlyBudget)
                {
                    Console.WriteLine("You have exceeded your budget!");
                }                   
                else
                {
                    Console.WriteLine($"You are within budget. Remaining: ${this.monthlyBudget - total}");
                }                    
            }
        }

        public void SetBudget()
        {
            Console.Write("\nenter monthly budget: ");
            string budget = Console.ReadLine();

            if (!decimal.TryParse(budget, out var amount))
            {
                Console.WriteLine("Invalid budget!");
                return;
            }

            this.monthlyBudget = amount;
            Console.WriteLine($"Monthly budget set to {budget}");
        }

        public void FilterByCategory()
        {
            if (!this.expenses.Any())
            {
                Console.WriteLine("No expenses available!");
                return;
            }

            Console.Write("\nenter category: ");
            string category = Console.ReadLine();

            var result = this.expenses.Where(
                e => e.Category.ToLower().Contains(category.ToLower()))
                .OrderByDescending(e => e.Date)
                .ToList();

            if (!result.Any())
            {
                Console.WriteLine("No expenses available!");
                return;
            }

            foreach (var e in result)
            {
                Console.WriteLine(e);
            }                
        }

        public void LoadExpenses()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var json = File.ReadAllText(FilePath);
                    this.expenses = JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
                }
                catch
                {
                    this.expenses = new List<Expense>();
                }
            }
        }

        public void SaveExpenses()
        {
            var json = JsonSerializer.Serialize(this.expenses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
