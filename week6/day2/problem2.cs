using System;

namespace Dotnet_C_Demo.HandsOn_week6_day2
{
    // Requirement 1: Create an interface for Discount Strategy
    // This allows the system to be 'Open for Extension'
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    // Requirement 2 & 3: Implement specific discount classes

    // Regular Customer: No discount
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => 0;
    }

    // Premium Customer: 10% discount
    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * 0.10;
    }

    // VIP Customer: 20% discount
    public class VIPCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * 0.20;
    }

    // Expectation: A class that calculates the final price
    // This class is 'Closed for Modification' because it works with the interface
    public class PriceCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy discountStrategy)
        {
            double discount = discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

    internal class problem2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- OCP: Discount Calculation System --- \n");

            PriceCalculator calculator = new PriceCalculator();
            double orderAmount = 1000.00;

            // Scenario 1: Regular Customer
            IDiscountStrategy regular = new RegularCustomerDiscount();
            Console.WriteLine($"Regular Customer Final Price: {calculator.GetFinalPrice(orderAmount, regular):C}");

            // Scenario 2: Premium Customer
            IDiscountStrategy premium = new PremiumCustomerDiscount();
            Console.WriteLine($"Premium Customer Final Price: {calculator.GetFinalPrice(orderAmount, premium):C}");

            // Scenario 3: VIP Customer
            IDiscountStrategy vip = new VIPCustomerDiscount();
            Console.WriteLine($"VIP Customer Final Price: {calculator.GetFinalPrice(orderAmount, vip):C}");

            Console.WriteLine("\nNote: You can add a 'GoldCustomer' class without changing PriceCalculator!");
            Console.ReadKey();
        }
    }
}