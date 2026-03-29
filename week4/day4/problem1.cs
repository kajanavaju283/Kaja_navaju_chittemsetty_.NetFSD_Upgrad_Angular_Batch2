using System;

namespace Dotnet_C_Demo.HandsOn_week4_day4
{
    // Requirement 1: Create a class named Calculator
    public class Calculator
    {
        // Requirement 2: Create Add method
        public int Add(int a, int b)
        {
            return a + b; // Requirement 3: Return the result
        }

        // Requirement 2: Create Subtract method
        public int Subtract(int a, int b)
        {
            return a - b; // Requirement 3: Return the result
        }
    }

    internal class problem1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Day 4: Simple Calculator Using Methods ---");

            // Accept inputs
            Console.Write("Enter First Number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            // Requirement 4: Create an object and call the methods
            Calculator myCalc = new Calculator();

            int additionResult = myCalc.Add(num1, num2);
            int subtractionResult = myCalc.Subtract(num1, num2);

            // Requirement 5: Display the output
            Console.WriteLine($"Addition = {additionResult}");
            Console.WriteLine($"Subtraction = {subtractionResult}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}