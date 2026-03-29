using System;
using System.Diagnostics; // Required for Trace and TextWriterTraceListener
using System.IO;

namespace Dotnet_C_Demo.HandsOn_week6_day1
{
    internal class problem5
    {
        static void Main(string[] args)
        {
            // Technical Constraint: Configure a TextWriterTraceListener to store logs in a file
            string logPath = "order_trace.log";
            TextWriterTraceListener logFile = new TextWriterTraceListener(File.CreateText(logPath));

            // Adding listeners: one for the file and one for the console
            Trace.Listeners.Add(logFile);
            Trace.Listeners.Add(new ConsoleTraceListener());

            // AutoFlush ensures data is written to the file immediately
            Trace.AutoFlush = true;

            Console.WriteLine("--- Order Processing with Tracing Enabled --- \n");
            Trace.WriteLine($"[Tracing Started at {DateTime.Now}]");

            try
            {
                // Requirement: The order processing should include specific steps

                // Step 1: Validate Order
                Trace.TraceInformation("Step 1: Validating Order...");
                ProcessStep("Order Validation", 1000);

                // Step 2: Process Payment
                Trace.TraceInformation("Step 2: Processing Payment...");
                ProcessStep("Payment Processing", 1500);

                // Step 3: Update Inventory
                Trace.TraceInformation("Step 3: Updating Inventory...");
                ProcessStep("Inventory Update", 1200);

                // Step 4: Generate Invoice
                Trace.TraceInformation("Step 4: Generating Invoice...");
                ProcessStep("Invoice Generation", 800);

                Trace.WriteLine("--- All steps completed successfully ---");
                Console.WriteLine("\nProcessing finished. Check 'order_trace.log' for details.");
            }
            catch (Exception ex)
            {
                // Trace logs help developers identify where the failure occurs
                Trace.WriteLine($"[CRITICAL ERROR] Process failed: {ex.Message}");
            }
            finally
            {
                Trace.WriteLine($"[Tracing Ended at {DateTime.Now}]\n");
                logFile.Close(); // Close the listener to release the file
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void ProcessStep(string stepName, int duration)
        {
            // Simulating work for each step
            System.Threading.Thread.Sleep(duration);
            Console.WriteLine($"-> Completed: {stepName}");
        }
    }
}