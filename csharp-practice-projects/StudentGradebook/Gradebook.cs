using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentGradebook
{
    internal class Gradebook
    {
        private List<Student> Students = new List<Student>();
        private const string FilePath = "gradebook.json";

        public void AddStudent()
        {
            Console.Write("\nStudent name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }

            this.Students.Add(new Student(name));
            Console.WriteLine("Student added successfully.");
        }

        public void AddGrade()
        {
            if (this.Students.Count == 0)
            {
                Console.WriteLine("No students available!");
                return;
            }
                        
            for (int i = 0; i < this.Students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this.Students[i].Name}");
            }

            Console.Write("Select a student:");
            string input = Console.ReadLine();

            bool isValid = int.TryParse(input, out int index);
            if (!isValid || index < 1 || index > this.Students.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var student = this.Students[index - 1];

            Console.Write("\nEnter subject: ");
            string subject = Console.ReadLine();

            Console.Write("Enter grade (0-100): ");
            string markStr = Console.ReadLine();

            bool isValidMark = double.TryParse(markStr, out double grade);
            if (!isValidMark || grade < 0 || grade > 100)
            {
                Console.WriteLine("Invalid grade.");
                return;
            }

            student.AddGrade(subject, grade);
            Console.WriteLine("Grade added successfully.");
        }

        public void DisplayAll()
        {
            if (this.Students.Count == 0)
            {
                Console.WriteLine("No students available!");
                return;
            }

            foreach (var student in this.Students)
            {
                Console.WriteLine("\n" + student);
                foreach (var mark in student.Marks)
                {
                    Console.WriteLine($"  - {mark.Subject}: {mark.Grade}");
                }
            }
        }

        public void SaveData()
        {
            var json = JsonSerializer.Serialize(this.Students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void LoadData()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var json = File.ReadAllText(FilePath);
                    this.Students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                }
                catch
                {
                    this.Students = new List<Student>();
                }
            }
        }
    }
}
