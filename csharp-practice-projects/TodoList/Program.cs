using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.LoadTasks();

            bool runAgain = true;
            while (runAgain)
            {
                string choice = GetChoice();

                switch (choice)
                {
                    case "1":
                        manager.DisplayTasks();

                        break;
                    case "2":
                        manager.AddTask();

                        break;
                    case "3":
                        manager.MarkCompleted();

                        break;
                    case "4":
                        manager.DeleteTask();

                        break;
                    case "x":
                    case "X":
                        manager.SaveTasks();
                        runAgain = false;

                        break;
                }                
            }

            Console.Clear();
            Console.WriteLine("------- Tasks saved successfully -------");
        }

        private static string GetChoice()
        {
            Console.WriteLine("\n------- Task Manager -------");
            Console.WriteLine("1 - View all tasks");
            Console.WriteLine("2 - Add new task");
            Console.WriteLine("3 - Mark task completed");
            Console.WriteLine("4 - Delete a task");
            Console.WriteLine("x - Save and exit");

            while (true)
            {
                Console.Write("\nyour choice: ");
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        return "1";
                    case "2":
                        return "2";
                    case "3":
                        return "3";
                    case "4":
                        return "4";
                    case "x":
                    case "X":
                        return "x";
                    default:
                        Console.WriteLine("Please enter a valid choice!");
                        break;
                }
            }
        }
    }
}
