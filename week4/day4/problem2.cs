using System;

namespace Dotnet_C_Demo.HandsOn_week4_day4
{
    // Requirement 1: Create a class Student
    public class Student
    {
        // Requirement 2: Create method CalculateAverage
        // Technical Constraint 1: Use return type double for average
        public double CalculateAverage(int m1, int m2, int m3)
        {
            // Requirement 3: Return the average marks
            double average = (m1 + m2 + m3) / 3.0;
            return average;
        }

        // Requirement 4: Method to determine Grade based on average
        public string GetGrade(double average)
        {
            if (average >= 90)
                return "A";
            else if (average >= 80)
                return "B";
            else if (average >= 70)
                return "C";
            else
                return "D";
        }
    }

    internal class problem2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Student Grade Calculator ---");

            // Technical Constraint 2: Avoid hard-coded values (Accept from user)
            Console.Write("Enter Marks for Subject 1: ");
            int mark1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Marks for Subject 2: ");
            int mark2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Marks for Subject 3: ");
            int mark3 = Convert.ToInt32(Console.ReadLine());

            // Creating object of Student class
            Student myStudent = new Student();

            // Calling methods
            double avg = myStudent.CalculateAverage(mark1, mark2, mark3);
            string grade = myStudent.GetGrade(avg);

            // Display Output
            Console.WriteLine($"\nAverage = {avg}, Grade = {grade}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}