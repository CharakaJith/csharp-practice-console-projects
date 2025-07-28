using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodoList
{
    public class Manager
    {
        private List<Task> tasks = new List<Task>();
        private const string FilePath = "tasks.json";

        public void AddTask()
        {
            Console.Write("\nTask description: ");
            string desc = Console.ReadLine();

            if (string.IsNullOrEmpty(desc))
            {
                Console.WriteLine("Task cannot be empty!");
                return;
            }

            this.tasks.Add(new Task
            {
                Id = this.tasks.Count + 1,
                Description = desc,
                IsCompleted = false,
            });
            Console.WriteLine("Task added");
        }

        public void DisplayTasks()
        {
            if (this.tasks.Count == 0)
            {
                Console.WriteLine("No tasks available!");
                return;
            }

            Console.WriteLine();
            foreach (Task task in this.tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }

        public void MarkCompleted()
        {
            if (this.tasks.Count == 0)
            {
                Console.WriteLine("No tasks available!");
                return;
            }

            DisplayTasks();
            Console.Write("Task id: ");
            string id = Console.ReadLine();

            if (!int.TryParse(id, out int index) || index <= 0 || index > this.tasks.Count)
            {
                Console.WriteLine("Invalid task id!");
                return;
            }

            this.tasks[index - 1].IsCompleted = true;
            Console.WriteLine("Task completed");
        }

        public void DeleteTask()
        {
            if (this.tasks.Count == 0)
            {
                Console.WriteLine("No tasks available!");
                return;
            }

            DisplayTasks();
            Console.Write("Task id: ");
            string id = Console.ReadLine();

            if (!int.TryParse(id, out int index) || index <= 0 || index > this.tasks.Count)
            {
                Console.WriteLine("Invalid task id!");
                return;
            }

            this.tasks.RemoveAt(index - 1);
            Console.WriteLine("Task deleted");
        }

        public void SaveTasks()
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void LoadTasks()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var json = File.ReadAllText(FilePath);
                    this.tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
                }
                catch
                {
                    this.tasks = new List<Task>();
                }
            }
        }
    }
}
