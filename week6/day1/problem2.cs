using System;

namespace Dotnet_C_Demo.HandsOn_week6_day1
{
    internal class problem2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Retail Product Discount Calculator --- \n");

            // Requirement: The program should accept Product Name, Price, and Discount Percentage
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Discount Percentage (e.g., 10 for 10%): ");
            double discountPercent = double.Parse(Console.ReadLine());

            // Requirement: Use the formula: FinalPrice = Price - (Price * Discount / 100)
            // DEBUGGING TIP: Place a breakpoint on the line below to inspect 'discountAmount'
            double discountAmount = (price * discountPercent) / 100;
            double finalPrice = price - discountAmount;

            // Requirement: Display the results clearly
            Console.WriteLine("\n--- Calculation Summary ---");
            Console.WriteLine($"Product Name       : {productName}");
            Console.WriteLine($"Original Price     : {price:C}");
            Console.WriteLine($"Discount Percentage: {discountPercent}%");
            Console.WriteLine($"Discount Value     : {discountAmount:C}");
            Console.WriteLine($"Final Payable Price: {finalPrice:C}");

            // Expectation: Use debugging tools to verify values during execution
            Console.WriteLine("\nDebug complete. Verify the Final Price using the Watch Window.");
            Console.ReadKey();
        }
    }
}