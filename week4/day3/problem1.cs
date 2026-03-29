using System;

namespace Dotnet_C_Demo.HandsOn_week4_day3
{
    internal class problem1
    {
        static void Main(string[] args)
        {
            // 1. Accepting Input from User
            Console.Write("Enter Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            // 2. Handling Invalid Input (Edge Cases)
            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid input! Marks should be between 0 and 100.");
            }
            else
            {
                string grade = "";

                // 3. Using if-else logic to determine Grade
                if (marks >= 90)
                {
                    grade = "A";
                }
                else if (marks >= 80)
                {
                    grade = "B";
                }
                else if (marks >= 70)
                {
                    grade = "C";
                }
                else if (marks >= 60)
                {
                    grade = "D";
                }
                else
                {
                    grade = "Fail";
                }

                // 4. Displaying Final Output
                Console.WriteLine("\n--- Student Result ---");
                Console.WriteLine("Student: " + studentName);
                Console.WriteLine("Grade: " + grade);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}