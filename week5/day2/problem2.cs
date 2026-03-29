using System;

namespace Dotnet_C_Demo.HandsOn_week5_day2
{
    // Requirement 1: Create a class Calculator
    public class Calculator
    {
        // Requirement 2: Create a method Divide
        public void Divide(int numerator, int denominator)
        {
            // Requirement 3 & Technical Constraint 1: Use try-catch-finally blocks
            try
            {
                // Requirement 4 & Technical Constraint 2: Handle DivideByZeroException
                int result = numerator / denominator;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                // Requirement 4: Display an appropriate error message
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (Exception ex)
            {
                // General error handling for other invalid values
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                // Technical Constraint 3: Ensure the finally block always executes
                // Requirement 5: Ensure the program continues execution
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    internal class problem2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Safe Division Calculator --- \n");

            Calculator myCalc = new Calculator();

            // Sample Input: Numerator = 20, Denominator = 0
            Console.WriteLine("Test Case 1: Division by Zero");
            myCalc.Divide(20, 0);

            Console.WriteLine("\n-------------------------------");

            // Test Case with valid input
            Console.WriteLine("Test Case 2: Valid Division");
            myCalc.Divide(20, 5);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}