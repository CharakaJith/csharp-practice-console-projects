using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebook
{
    internal class GradebookSystem
    {
        public void Run()
        {
            Gradebook gradebook = new Gradebook();
            gradebook.LoadData();

            bool runAgain = true;
            while (runAgain)
            {
                SystemOperations operations = SelectOperation();

                switch (operations)
                {
                    case SystemOperations.AddStudent:
                        gradebook.AddStudent();
                        break;
                    case SystemOperations.AddGrade:
                        gradebook.AddGrade();
                        break;
                    case SystemOperations.ViewAllStudents:
                        gradebook.DisplayAll();
                        break;
                    case SystemOperations.Exit:
                        gradebook.SaveData();
                        runAgain = false;
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("------- Details saved successfully -------");
        }

        private SystemOperations SelectOperation()
        {
            Console.WriteLine("\n------- Gradebook System -------");
            Console.WriteLine("1 - Add student");
            Console.WriteLine("2 - Add grade");
            Console.WriteLine("3 - View all students");
            Console.WriteLine("x - Save and exit");

            while (true)
            {
                Console.Write("\nselect operation: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return SystemOperations.AddStudent;
                    case "2":
                        return SystemOperations.AddGrade;
                    case "3":
                        return SystemOperations.ViewAllStudents;
                    case "x":
                    case "X":
                        return SystemOperations.Exit;
                    default:
                        Console.WriteLine("Please enter a valid operation!");
                        break;
                }
            }
        }
    }
}
