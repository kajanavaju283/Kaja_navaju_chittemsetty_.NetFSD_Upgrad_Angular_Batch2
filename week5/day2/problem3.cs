using System;

namespace Dotnet_C_Demo.HandsOn_week5_day2
{
    // Requirement 3 & Technical Constraint 1: Create a custom exception class
    // Inheriting from Exception class
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    // Requirement 1: Create a class BankAccount
    public class BankAccount
    {
        // Requirement 1: Private field balance
        private double balance;

        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }

        // Requirement 2: Create a method Withdraw
        public void Withdraw(double amount)
        {
            // Requirement 4 & Technical Constraint 2: Throw custom exception if amount exceeds balance
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine($"Successfully withdrawn: {amount}");
            Console.WriteLine($"Remaining Balance: {balance}");
        }
    }

    internal class problem3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Bank Withdrawal System --- \n");

            // Sample Input: Balance = 3000
            BankAccount myAccount = new BankAccount(3000);

            // Requirement 5 & Technical Constraint 3: Handle the exception using try-catch
            try
            {
                Console.WriteLine("Attempting to withdraw 5000...");
                myAccount.Withdraw(5000);
            }
            catch (InsufficientBalanceException ex)
            {
                // Display user-friendly error message
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                // Requirement 6: Ensure proper cleanup using a finally block
                Console.WriteLine("Transaction process finished.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}