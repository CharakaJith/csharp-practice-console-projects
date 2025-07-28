using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime? DueDate { get; set; }

        public override string ToString()
        {
            if (this.IsBorrowed)
            {
                return $"{Id}. \"{Title}\" by {Author} - Borrowed (Due: {DueDate?.ToShortDateString()})";
            }

            return $"{Id}. \"{Title}\" by {Author} - Available";
        }
    }
}
