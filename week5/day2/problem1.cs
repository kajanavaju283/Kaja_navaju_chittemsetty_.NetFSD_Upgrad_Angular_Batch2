using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet_C_Demo.HandsOn_week5_day2
{
    // Requirement 1 & Technical Constraint 1: Define a Record to store student details
    public record Student(int RollNumber, string Name, string Course, int Marks);

    internal class problem1
    {
        static void Main(string[] args)
        {
            // Technical Constraint 2: Use a list of records to store multiple students
            List<Student> studentList = new List<Student>();

            Console.WriteLine("--- Student Record Management System ---");

            // Requirement 2: Allow user to input details for multiple students
            Console.Write("Enter number of students: ");
            if (int.TryParse(Console.ReadLine(), out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"\nEnter details for Student {i + 1}:");

                    // Technical Constraint 5: Input validation for Roll Number and Marks
                    Console.Write("Enter Roll Number: ");
                    int roll = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Course: ");
                    string course = Console.ReadLine();

                    Console.Write("Enter Marks: ");
                    int marks = int.Parse(Console.ReadLine());

                    // Adding record to the list
                    studentList.Add(new Student(roll, name, course, marks));
                }
            }

            // Requirement 3: Display all student records in a formatted manner
            Console.WriteLine("\n--- All Student Records ---");
            foreach (var s in studentList)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }

            // Requirement 4: Provide search functionality to find a student by Roll Number
            Console.Write("\nEnter Roll Number to search: ");
            int searchRoll = int.Parse(Console.ReadLine());

            var foundStudent = studentList.FirstOrDefault(s => s.RollNumber == searchRoll);

            // Requirement 5: Display appropriate message if the record is not found
            if (foundStudent != null)
            {
                Console.WriteLine("\nStudent Found:");
                Console.WriteLine($"Roll No: {foundStudent.RollNumber} | Name: {foundStudent.Name} | Course: {foundStudent.Course} | Marks: {foundStudent.Marks}");
            }
            else
            {
                Console.WriteLine("\nError: Student record not found!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}