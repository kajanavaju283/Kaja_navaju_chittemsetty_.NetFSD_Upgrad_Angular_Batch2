using System;
using System.Threading.Tasks; // Required for Task and async/await

namespace Dotnet_C_Demo.HandsOn_week6_day1
{
    internal class problem1
    {
        // Requirement 1: Create an asynchronous method WriteLogAsync
        // Technical Constraint 1: Use async and await keywords
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"[Process Started] Attempting to log: {message}");

            // Technical Constraint 2: Use Task.Delay() to simulate file I/O
            // Simulates the time taken to write to a physical file (2 seconds)
            await Task.Delay(2000);

            Console.WriteLine($"[Process Completed] Log written: {message} at {DateTime.Now:HH:mm:ss}");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("--- Asynchronous File Logging System --- \n");

            // Requirement 3: Call this method multiple times to simulate different events
            // These tasks start running in the background immediately
            Task log1 = WriteLogAsync("User 'Kaja' accessed the dashboard.");
            Task log2 = WriteLogAsync("System update check performed.");
            Task log3 = WriteLogAsync("Warning: High memory usage detected.");

            // Expectation: The main thread should remain responsive while logging occurs
            Console.WriteLine("\n[Main Thread] Status: Active and responsive.");
            Console.WriteLine("[Main Thread] Notice: Background logging is in progress...\n");

            // Learning Outcome: Ensuring the app waits for all background tasks before closing
            await Task.WhenAll(log1, log2, log3);

            Console.WriteLine("\nAll events have been logged successfully.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}