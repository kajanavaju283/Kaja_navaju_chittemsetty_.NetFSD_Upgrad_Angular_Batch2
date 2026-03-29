using System;
using System.Collections.Generic;

namespace Dotnet_C_Demo.HandsOn_week6_day2
{
    // 1. Student Class: Responsible only for holding data properties
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }
    }

    // 2. StudentRepository Class: Responsible only for managing student data
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student {student.StudentName} added to the repository.");
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }

    // 3. ReportGenerator Class: Responsible only for formatting and displaying reports
    public class ReportGenerator
    {
        public void GeneratePerformanceReport(List<Student> students)
        {
            Console.WriteLine("\n--- Student Performance Report ---");
            Console.WriteLine("ID\tName\t\tMarks");
            Console.WriteLine("----------------------------------");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentId}\t{student.StudentName}\t\t{student.Marks}");
            }
            Console.WriteLine("----------------------------------");
        }
    }

    // Main program to coordinate the classes
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- SRP Demonstration: Student Management System --- \n");

            // Initialize the Repository and Report Generator
            StudentRepository repository = new StudentRepository();
            ReportGenerator reportGenerator = new ReportGenerator();

            // Adding students using the repository
            repository.AddStudent(new Student { StudentId = 101, StudentName = "Kaja", Marks = 85 });
            repository.AddStudent(new Student { StudentId = 102, StudentName = "Rahul", Marks = 92 });

            // Generating the report using the report generator
            List<Student> allStudents = repository.GetAllStudents();
            reportGenerator.GeneratePerformanceReport(allStudents);

            Console.WriteLine("\nProcess complete. SRP implemented by separating Storage from Reporting.");
            Console.ReadKey();
        }
    }
}