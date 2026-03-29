using System;

namespace Dotnet_C_Demo.HandsOn_week4_day5
{
    // Requirement 1: Create class BankAccount
    public class BankAccount
    {
        // Technical Constraint 1: Balance must be private (Encapsulation)
        private double balance;

        // Requirement 3: Public method to Deposit money
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Successfully deposited: {amount}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        // Requirement 3 & 5: Public method to Withdraw money with safety check
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
            }
            else if (amount > balance) // Requirement 5: Prevent withdrawal if insufficient balance
            {
                Console.WriteLine("Error: Insufficient balance!");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Successfully withdrawn: {amount}");
            }
        }

        // Requirement 4: Method GetBalance to return current balance
        public double GetBalance()
        {
            return balance;
        }
    }

    internal class problem1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Day 5: Bank Account Management ---");

            // Creating object of BankAccount
            BankAccount myAccount = new BankAccount();

            // Sample Input: Deposit 1000
            myAccount.Deposit(1000);

            // Sample Input: Withdraw 300
            myAccount.Withdraw(300);

            // Sample Output: Current Balance
            Console.WriteLine($"\nCurrent Balance = {myAccount.GetBalance()}");

            // Extra Check: Try to withdraw more than balance
            Console.WriteLine("\nTrying to withdraw 1000 more...");
            myAccount.Withdraw(1000);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
