using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    internal class Expense
    {
        public string Category {  get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Date.ToString("yyyy-MM-dd")} | {Category,-10} | ${Amount,8} | {Note}";
        }
    }
}
