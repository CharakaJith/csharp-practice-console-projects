using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactBookManager manager = new ContactBookManager();
            manager.LoadContacts();

            bool runAgain = true;
            while (runAgain)
            {
                ContactOperations operation = SelectOperation();
                switch (operation)
                {
                    case ContactOperations.ViewAll:
                        manager.ViewAllContacts();

                        break;
                    case ContactOperations.AddNew:
                        manager.AddNewContact();

                        break;
                    case ContactOperations.Update:
                        manager.UpdateContact();

                        break;
                    case ContactOperations.Delete:
                        manager.DeleteContact();

                        break;
                    case ContactOperations.SearchByName:
                        manager.SearchByName();

                        break;

                    case ContactOperations.SortByName:
                        manager.SortByName();

                        break;
                    case ContactOperations.ExportToCSV:
                        manager.ExportToCSV(); 
                        
                        break;
                    case ContactOperations.Exit:
                        manager.SaveContacts();
                        runAgain = false;

                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("------- Thank you for using the contact manager -------");
        }

        private static ContactOperations SelectOperation()
        {
            Console.WriteLine("\n------- Contact Book -------");
            Console.WriteLine("1 - View all contacts");
            Console.WriteLine("2 - Add new contact");
            Console.WriteLine("3 - Update a contacct");
            Console.WriteLine("4 - Delete a contact");
            Console.WriteLine("5 - Search contact by name");
            Console.WriteLine("6 - Sort contacts by name");
            Console.WriteLine("7 - Export to CSV");
            Console.WriteLine("x - Save and exit");

            while(true)
            {
                Console.Write("\nselect operation: ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        return ContactOperations.ViewAll;
                    case "2":
                        return ContactOperations.AddNew;
                    case "3":
                        return ContactOperations.Update;
                    case "4":
                        return ContactOperations.Delete;
                    case "5":
                        return ContactOperations.SearchByName;
                    case "6":
                        return ContactOperations.SortByName;
                    case "7":
                        return ContactOperations.ExportToCSV;
                    case "X":
                    case "x":
                        return ContactOperations.Exit;
                    default:
                        Console.WriteLine("Please enter a valid operation!");
                        break;
                }
            }
        }
    }
}
