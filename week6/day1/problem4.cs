using System;
using System.Threading.Tasks; // Required for Task-based asynchronous methods

namespace Dotnet_C_Demo.HandsOn_week6_day1
{
    internal class problem4
    {
        // Requirement: Create asynchronous method for Payment Verification
        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("[Step 1] Verifying payment...");
            // Requirement: Simulate processing delays using Task.Delay()
            await Task.Delay(2000);
            Console.WriteLine("[Step 1] Payment verified successfully.");
        }

        // Requirement: Create asynchronous method for Inventory Check
        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("[Step 2] Checking inventory stock...");
            await Task.Delay(1500);
            Console.WriteLine("[Step 2] Inventory check completed. Items are in stock.");
        }

        // Requirement: Create asynchronous method for Order Confirmation
        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("[Step 3] Confirming your order...");
            await Task.Delay(1000);
            Console.WriteLine("[Step 3] Order confirmed! Shipping details sent to email.");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("--- E-Commerce Order Processing System --- \n");
            Console.WriteLine("Order received. Starting asynchronous workflow...\n");

            // Requirement: Execute steps asynchronously while maintaining logical order
            // Technical Constraint: Use async and await
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();

            // Expectation: Display messages indicating the progress of order processing
            Console.WriteLine("\n--- Order Processed Successfully ---");
            Console.WriteLine("Thank you for your purchase!");

            Console.ReadKey();
        }
    }
}