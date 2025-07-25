using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    internal class Calculator
    {
        public void Start()
        {
            bool runAgain = true;
            while (runAgain)
            {
                Operations operation = SelectOperation();

                if (operation == Operations.SquareRoot)
                {
                    RunUneryOpt(operation);
                }
                else if (operation == Operations.Exit)
                {
                    runAgain = false;
                }
                else
                {
                    RunBinaryOpt(operation);
                }
            }

            Console.Clear();
            Console.WriteLine("------- Thank you -------");
        }

        private Operations SelectOperation()
        {
            Console.WriteLine("------- Simple Calculator -------");
            Console.WriteLine("\nSelect operation: ");
            Console.WriteLine($"1 - {Operations.Addition} (+)");
            Console.WriteLine($"2 - {Operations.Subtraction} (-)");
            Console.WriteLine($"3 - {Operations.Multiplication} (x)");
            Console.WriteLine($"4 - {Operations.Division} (/)");
            Console.WriteLine($"5 - {Operations.Power} (^)");
            Console.WriteLine($"6 - Square Root (√)");
            Console.WriteLine($"x - {Operations.Exit}");

            while(true)
            {
                Console.Write("\nyour choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return Operations.Addition;
                    case "2":
                        return Operations.Subtraction;
                    case "3":
                        return Operations.Multiplication;
                    case "4":
                        return Operations.Division;
                    case "5":
                        return Operations.Power;
                    case "6":
                        return Operations.SquareRoot;
                    case "X":
                    case "x":
                        return Operations.Exit;
                    default:
                        Console.WriteLine("Please enter a valid choice!");
                        break;
                }
            }
        }

        private void RunBinaryOpt(Operations opt)
        {
            Console.WriteLine();
            double num1 = ReadConsoleInput("your first number");
            double num2 = ReadConsoleInput("your second number");

            double result = 0.0;
            string symbol = "";
            switch (opt)
            {
                case Operations.Addition:
                    symbol = "+";
                    result = num1 + num2;

                    break;
                case Operations.Subtraction:
                    symbol = "-";
                    result = num1 - num2;

                    break;
                case Operations.Multiplication:
                    symbol = "x";
                    result = num1 * num2;

                    break;
                case Operations.Division:
                    if (num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return;
                    }

                    symbol = "/";
                    result = num1 / num2;
                    
                    break;
                case Operations.Power:
                    symbol = "^";
                    result = Math.Pow(num1, num2);

                    break;
            }

            Console.WriteLine($"\n{num1} {symbol} {num2} = {result}\n");
        }

        private void RunUneryOpt(Operations opt)
        {
            Console.WriteLine();
            double num = ReadConsoleInput("your number");

            double result = 0.0;
            string symbol = "";
            switch (opt)
            {
                case Operations.SquareRoot:
                    if (num < 0)
                    {
                        Console.WriteLine("Cannot compute square root of a negative number.");
                        return;
                    }

                    symbol = "√";
                    result = Math.Sqrt(num);

                    break;
            }

            Console.WriteLine($"\n{symbol}{num} = {result}\n");
        }

        private double ReadConsoleInput(string message)
        {
            double value;
            while(true)
            {
                Console.Write($"{message}: ");
                string input = Console.ReadLine();

                bool isSuccess = double.TryParse(input, out value);
                if (isSuccess)
                {
                    return value;
                }

                Console.WriteLine("Please enter a valid number!");
            }
        }
    }
}
