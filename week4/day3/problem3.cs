using System;

namespace Dotnet_C_Demo.HandsOn_week4_day3
{
    internal class problem3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Employee Bonus Calculator ---");

            // Accept inputs from user
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Experience (in years): ");
            int experience = Convert.ToInt32(Console.ReadLine());

            double bonusPercentage = 0;

            // Using if-else to determine bonus percentage based on rules
            if (experience < 2)
            {
                bonusPercentage = 5;
            }
            else if (experience >= 2 && experience <= 5)
            {
                bonusPercentage = 10;
            }
            else
            {
                bonusPercentage = 15;
            }

            // Calculating bonus amount
            double bonusAmount = (salary * bonusPercentage) / 100;

            // Using ternary operator for final check or formatting (Technical Constraint)
            double finalSalary = salary + bonusAmount;

            // Display Output with proper formatting
            Console.WriteLine("\n--- Sample Output ---");
            Console.WriteLine($"Employee: {name}");
            Console.WriteLine($"Bonus: {bonusAmount:C}"); // :C adds currency formatting
            Console.WriteLine($"Final Salary: {finalSalary:C}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}