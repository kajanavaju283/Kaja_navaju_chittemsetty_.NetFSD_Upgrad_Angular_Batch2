using System;

namespace Dotnet_C_Demo.HandsOn_week4_day4
{
    internal class problem4
    {
        // Requirement: Create a method with Optional Parameters
        // Default discount = 0, Default shipping = 50
        static void CalculateFinalAmount(double price, int quantity, double discountPercentage = 0, double shippingCharge = 50)
        {
            double subtotal = price * quantity;

            // Technical Constraint: Discount should be applied before adding shipping charges
            double discountAmount = (subtotal * discountPercentage) / 100;
            double finalAmount = (subtotal - discountAmount) + shippingCharge;

            // Output expectations
            Console.WriteLine($"Subtotal: {subtotal:F2}");
            Console.WriteLine($"Discount Applied ({discountPercentage}%): {discountAmount:F2}");
            Console.WriteLine($"Shipping Charge: {shippingCharge:F2}");
            Console.WriteLine($"Final Payable Amount: {finalAmount:F2}");
            Console.WriteLine("-------------------------------------------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- E-Commerce Order Calculator --- \n");

            // Requirement: Call the method with different combinations of parameters

            Console.WriteLine("Scenario 1: Only Price and Quantity (Using Defaults)");
            CalculateFinalAmount(1000, 2); // Uses 0% discount and 50 shipping

            Console.WriteLine("Scenario 2: With 10% Discount");
            CalculateFinalAmount(1000, 2, 10); // Uses 50 shipping as default

            Console.WriteLine("Scenario 3: With 10% Discount and 100 Shipping");
            CalculateFinalAmount(1000, 2, 10, 100); // Uses all provided values

            Console.WriteLine("Scenario 4: Using Named Parameters (Skip discount, provide shipping)");
            CalculateFinalAmount(1000, 2, shippingCharge: 80);

            Console.ReadKey();
        }
    }
}