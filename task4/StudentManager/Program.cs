using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }
    }

    static void Main()
    {
        var students = new List<Student>
        {
            new Student { Name = "B", Grade = 92, Age = 22 },
            new Student { Name = "E", Grade = 95, Age = 23 },
            new Student { Name = "C", Grade = 78, Age = 19 },
            new Student { Name = "A", Grade = 85, Age = 20 },
            new Student { Name = "D", Grade = 88, Age = 21 }
        };

        var topStudents = students
            .Where(s => s.Grade > 80)
            .OrderBy(s => s.Name)
            .ToList();

        Console.WriteLine("Students with Grade > 80, sorted by Name:\n");

        foreach (var student in topStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}, Age: {student.Age}");
        }
    }
}
