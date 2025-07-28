using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class LibraryManager
    {
        List<Book> books = new List<Book>();
        private const string FilePath = "books.json";

        public void ViewAllBooks()
        {
            if (this.books.Count == 0)
            {
                Console.WriteLine("No books available!");
                return;
            }

            Console.WriteLine();
            foreach (Book book in this.books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void SearchByName()
        {
            if (this.books.Count == 0)
            {
                Console.WriteLine("No books available!");
                return;
            }

            Console.Write("\nbook title: ");
            string title = Console.ReadLine();

            var results = this.books.Where(b => b.Title.ToLower().Contains(title)).ToList();
            if (results.Count == 0)
            {
                Console.WriteLine("No books found!");
                return;
            }

            foreach (Book book in results)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void BorrowBook()
        {
            if (this.books.Count == 0)
            {
                Console.WriteLine("No books available!");
                return;
            }

            int count = 0;
            foreach (Book book in this.books)
            {
                if (!book.IsBorrowed)
                {
                    Console.WriteLine($"{count + 1} - {book.Title}");
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("All the books are borrowed!");
                return;
            }

            Console.Write("book id: ");
            string id = Console.ReadLine();

            if (!int.TryParse(id, out int index) || index <= 0 || index > count)
            {
                Console.WriteLine("Invalid book id!");
                return;
            }

            var bookToBorrow = this.books[index];

            bookToBorrow.IsBorrowed = true;
            bookToBorrow.DueDate = DateTime.Now.AddDays(14);
            Console.WriteLine($"You burrowed {bookToBorrow.ToString()}");
        }

        public void ReturnBook()
        {
            if (this.books.Count == 0)
            {
                Console.WriteLine("No books available!");
                return;
            }

            int count = 0;
            foreach (Book book in this.books)
            {
                if (book.IsBorrowed)
                {
                    Console.WriteLine($"{count + 1} - {book.Title}");
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("No books has been borrowed yet!");
                return;
            }

            Console.Write("book id: ");
            string id = Console.ReadLine();

            if (!int.TryParse(id, out int index) || index <= 0 || index > count)
            {
                Console.WriteLine("Invalid book id!");
                return;
            }

            this.books[index].IsBorrowed = false;
            Console.WriteLine("Book returned");
        }

        public void AddNewBook()
        {
            Console.Write("\nbook title: ");
            string title = Console.ReadLine();

            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title cannot be empty!");
                return;
            }

            Console.Write("author: ");
            string author = Console.ReadLine();

            if (string.IsNullOrEmpty(author))
            {
                Console.WriteLine("Author cannot be empty!");
                return;
            }

            this.books.Add(new Book
            {
                Id = this.books.Count + 1,
                Title = title,
                Author = author,
                IsBorrowed = false,
                DueDate = null,
            });
        }

        public void SaveDetails()
        {
            var json = JsonSerializer.Serialize(this.books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void LoadBooks()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var json = File.ReadAllText(FilePath);
                    this.books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                }
                catch
                {
                    this.books = new List<Book>();
                }
            }
        }
    }
}
