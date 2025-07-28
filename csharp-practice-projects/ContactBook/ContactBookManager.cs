using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactBook
{
    internal class ContactBookManager
    {
        private List<Contact> contacts = new List<Contact>();
        private const string FilePath = "contacts.json";
        private const string CsvPath = "contacts.csv";

        public void ViewAllContacts()
        {
            if (!this.contacts.Any())
            {
                Console.WriteLine("No contacts available!");
                return;
            }

            Console.WriteLine();
            foreach (Contact contact in this.contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void AddNewContact()
        {
            Console.Write("\nname: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }

            Console.Write("email: ");
            string mail = Console.ReadLine();

            if (string.IsNullOrEmpty(mail))
            {
                Console.WriteLine("Email cannot be empty!");
                return;
            }

            Console.Write("mobile number: ");
            string phone = Console.ReadLine();

            if (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("Mobile number cannot be empty!");
                return;
            }

            var existingContacts = this.contacts.Where(
                c => c.Name.ToLower().Contains(name) || 
                c.Email.ToLower().Contains(mail) || 
                c.Phone.Equals(phone)    
            ).ToList();

            if (existingContacts.Any())
            {
                Console.WriteLine("This contact is already saved!");
                return;
            }

            this.contacts.Add(new Contact
            {
                Name = name,
                Email = mail,
                Phone = phone,
            });
            Console.WriteLine("Your contact saved");
        }

        public void UpdateContact()
        {
            if (!this.contacts.Any())
            {
                Console.WriteLine("No contacts available!");
                return;
            }

            Console.Write("\ncontact name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
            }

            Contact contact = this.contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
            {
                Console.WriteLine("Contact does not exist!");
                return;
            }

            Console.Write("New email (leave blank to keep unchanged): ");
            var email = Console.ReadLine();

            Console.Write("New phone (leave blank to keep unchanged): ");
            var phone = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(phone)) contact.Phone = phone;
            if (!string.IsNullOrWhiteSpace(email)) contact.Email = email;

            Console.WriteLine("Contact updated");
        }

        public void DeleteContact()
        {
            if (!this.contacts.Any())
            {
                Console.WriteLine("No contacts available!");
                return;
            }

            Console.Write("\ncontact name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
            }

            Contact contact = this.contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
            {
                Console.WriteLine("Contact does not exist!");
                return;
            }

            this.contacts.Remove(contact);
            Console.WriteLine("Contact deleted");
        }

        public void SearchByName()
        {
            if (!this.contacts.Any())
            {
                Console.WriteLine("No contacts available!");
                return;
            }

            Console.Write("\ncontact name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
            }

            var contactsFound = this.contacts.Where(c => c.Name.ToLower().Contains(name)).ToList();
            if (contactsFound.Count == 0)
            {
                Console.WriteLine("No contacts found!");
                return;
            }

            Console.WriteLine();
            foreach (Contact c in contactsFound)
            {
                Console.WriteLine(c.ToString());
            }
        }

        public void SortByName()
        {
            if (!this.contacts.Any())
            {
                Console.WriteLine("No contacts available!");
                return;
            }

            this.contacts = this.contacts.OrderBy(c => c.Name).ToList();
            Console.WriteLine("Contacts sorted");
        }

        public void ExportToCSV()
        {
            if (!this.contacts.Any())
            {
                Console.WriteLine("No contacts available!");
                return;
            }

            using (var writer = new StreamWriter(CsvPath))
            {
                writer.WriteLine("Name,Phone,Email");

                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.Name},{contact.Phone},{contact.Email}");

                }                    
            }

            Console.WriteLine($"Contacts exported to '{CsvPath}'.");
        }

        public void SaveContacts()
        {
            var json = JsonSerializer.Serialize(this.contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void LoadContacts()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var json = File.ReadAllText(FilePath);
                    this.contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
                }
                catch
                {
                    this.contacts = new List<Contact>();
                }
            }
        }
    }
}
