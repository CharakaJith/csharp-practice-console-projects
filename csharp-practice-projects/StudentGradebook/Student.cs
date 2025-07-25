using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebook
{
    internal class Student
    {
        public string Name {  get; set; }
        public List<SubjectGrade> Marks { get; set; }

        public Student(string name)
        {
            this.Name = name;
            this.Marks = new List<SubjectGrade>();
        }

        public void AddGrade(string subject, double grade)
        {
            Marks.Add(
                new SubjectGrade
                {
                    Subject = subject,
                    Grade = grade
                }
            );
        }

        public double Gpa()
        {
            if (this.Marks.Count == 0)
            {
                return 0;
            }

            return this.Marks.Average(g => g.Grade);
        }

        public override string ToString()
        {
            return $"{this.Name} | GPA: {Gpa():0.00} | Subjects: {this.Marks.Count}";
        }
    }    
}
