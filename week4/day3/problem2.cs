using System;

namespace Dotnet_C_Demo.HandsOn_week4_day3
{
    internal class problem2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Simple Calculator ---");

            // Accept two numbers
            Console.Write("Enter First Number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // Accept operator
            Console.Write("Enter Operator (+, -, *, /): ");
            char op = Convert.ToChar(Console.ReadLine());

            double result = 0;
            bool validOperation = true;

            // Switch case to perform operation
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    // Handle division by zero
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        validOperation = false;
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid Operator selected.");
                    validOperation = false;
                    break;
            }

            // Display result
            if (validOperation)
            {
                Console.WriteLine($"Result: {result}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}