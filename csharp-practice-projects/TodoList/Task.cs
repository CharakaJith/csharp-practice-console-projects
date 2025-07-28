using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{Id} - {(IsCompleted ? "[X]" : "[ ]")} {Description}";
        }
    }
}
