using System;
using System.Threading;
using System.Threading.Tasks; // Required for Task class

namespace Dotnet_C_Demo.HandsOn_week6_day1
{
    internal class problem3
    {
        // Requirement 1a: Create method to generate Sales Report
        static void GenerateSalesReport()
        {
            Console.WriteLine("[Start] Generating Sales Report...");
            // Requirement 2: Simulate processing time using Thread.Sleep or Task.Delay
            Thread.Sleep(3000);
            Console.WriteLine("[Finish] Sales Report is ready.");
        }

        // Requirement 1b: Create method to generate Inventory Report
        static void GenerateInventoryReport()
        {
            Console.WriteLine("[Start] Generating Inventory Report...");
            Thread.Sleep(2000);
            Console.WriteLine("[Finish] Inventory Report is ready.");
        }

        // Requirement 1c: Create method to generate Customer Report
        static void GenerateCustomerReport()
        {
            Console.WriteLine("[Start] Generating Customer Report...");
            Thread.Sleep(2500);
            Console.WriteLine("[Finish] Customer Report is ready.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Financial Report Generation System --- \n");

            // Requirement 3: Execute all three operations concurrently using Task
            // Technical Constraint: Use Task.Run() to execute methods
            Task task1 = Task.Run(() => GenerateSalesReport());
            Task task2 = Task.Run(() => GenerateInventoryReport());
            Task task3 = Task.Run(() => GenerateCustomerReport());

            Console.WriteLine("\nAll report tasks have been triggered. Waiting for completion...\n");

            // Technical Constraint: Use Task.WaitAll() to wait for completion
            Task.WaitAll(task1, task2, task3);

            // Requirement 5: Display a final message once all reports are completed
            Console.WriteLine("\n--- All financial reports have been generated successfully ---");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}