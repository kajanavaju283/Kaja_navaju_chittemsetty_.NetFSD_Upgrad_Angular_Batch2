using System;

namespace Dotnet_C_Demo.HandsOn_week4_day3
{
    internal class problem4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Number Analysis Using Loops ---");

            // Accept a number N from the user
            Console.Write("Enter Number N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            // Use loop to analyze numbers between 1 and N
            for (int i = 1; i <= n; i++)
            {
                // Calculate sum of all numbers
                sum += i;

                // Check for even or odd
                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            // Display results
            Console.WriteLine("\n--- Sample Output ---");
            Console.WriteLine($"Even Count: {evenCount}");
            Console.WriteLine($"Odd Count: {oddCount}");
            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}