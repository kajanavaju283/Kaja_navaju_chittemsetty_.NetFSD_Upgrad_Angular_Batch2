using System;

namespace Dotnet_C_Demo.HandsOn_week4_day4
{
    internal class problem3
    {
        // Requirement 1: Create a method CalculateResult
        // Technical Constraint: Use out parameters to return total and average
        static void CalculateResult(int m1, int m2, int m3, out int total, out double average)
        {
            total = m1 + m2 + m3;
            average = total / 3.0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Student Result Analyzer (out Parameters) ---");

            // Requirement: Allow testing for multiple students (using a simple loop)
            string choice;
            do
            {
                // Input validation: Marks must be between 0 and 100
                int mark1 = GetValidMark("Subject 1");
                int mark2 = GetValidMark("Subject 2");
                int mark3 = GetValidMark("Subject 3");

                // Calling method with out parameters
                CalculateResult(mark1, mark2, mark3, out int totalMarks, out double avgMarks);

                // Display Results
                Console.WriteLine($"\nTotal Marks: {totalMarks}");
                Console.WriteLine($"Average Marks: {avgMarks:F2}");

                // Requirement: Pass if average >= 40
                if (avgMarks >= 40)
                    Console.WriteLine("Status: Pass");
                else
                    Console.WriteLine("Status: Fail");

                Console.Write("\nDo you want to check for another student? (yes/no): ");
                choice = Console.ReadLine().ToLower();

            } while (choice == "yes");

            Console.WriteLine("Thank you!");
            Console.ReadKey();
        }

        // Helper method for input validation
        static int GetValidMark(string subjectName)
        {
            int mark;
            while (true)
            {
                Console.Write($"Enter marks for {subjectName} (0-100): ");
                if (int.TryParse(Console.ReadLine(), out mark) && mark >= 0 && mark <= 100)
                {
                    return mark;
                }
                Console.WriteLine("Invalid Input! Please enter marks between 0 and 100.");
            }
        }
    }
}