using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryManager libraryManager = new LibraryManager();
            libraryManager.LoadBooks();

            bool runAgain = true;
            while (runAgain)
            {
                LibraryOperations operation = GetOperation();

                switch (operation)
                {
                    case LibraryOperations.ViewAll:
                        libraryManager.ViewAllBooks();

                        break;
                    case LibraryOperations.SearchByName:
                        libraryManager.SearchByName();

                        break;
                    case LibraryOperations.Borrow:
                        libraryManager.BorrowBook();

                        break;
                    case LibraryOperations.Return:
                        libraryManager.ReturnBook();

                        break;
                    case LibraryOperations.AddBook:
                        libraryManager.AddNewBook();

                        break;
                    case LibraryOperations.Exit:
                        libraryManager.SaveDetails();
                        runAgain = false;

                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("------- Thank you for using our system -------");
        }

        private static LibraryOperations GetOperation()
        {
            Console.WriteLine("\n------- Library Management System -------");
            Console.WriteLine("1 - View all books");
            Console.WriteLine("2 - Search book by name");
            Console.WriteLine("3 - Borrow a book");
            Console.WriteLine("4 - Return a book");
            Console.WriteLine("5 - Add new book");
            Console.WriteLine("x - Save and exit");

            while (true)
            {
                Console.Write("\nSelect operation: ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        return LibraryOperations.ViewAll;
                    case "2":
                        return LibraryOperations.SearchByName;
                    case "3":
                        return LibraryOperations.Borrow;
                    case "4":
                        return LibraryOperations.Return;
                    case "5":
                        return LibraryOperations.AddBook;
                    case "x":
                    case "X":
                        return LibraryOperations.Exit;
                    default:
                        Console.WriteLine("Please enter a valid operation!");
                        break;
                }
            }
        }
    }
}
