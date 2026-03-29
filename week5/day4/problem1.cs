using System;
using System.IO;
using System.Text;

namespace Dotnet_C_Demo.HandsOn_week5_day4
{
    internal class problem1
    {
        static void Main(string[] args)
        {
            // Path where the log file will be created
            string filePath = "log_messages.txt";

            Console.WriteLine("--- Simple Log Message Writer ---");

            try
            {
                // Requirement 1: Accept a message from the user
                Console.Write("Enter a message to log: ");
                string userMessage = Console.ReadLine() + Environment.NewLine;

                // Requirement 2 & Technical Constraint: Use FileStream class
                // Requirement 3: Append multiple messages to the same file
                // Using FileMode.Append to add data without deleting old content
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    // Converting string message to byte array as FileStream works with bytes
                    byte[] data = Encoding.UTF8.GetBytes(userMessage);

                    // Writing data to the file
                    fs.Write(data, 0, data.Length);
                }

                // Requirement 4: Display confirmation after writing the data
                Console.WriteLine("\nSuccess: Message has been logged to the file.");
                Console.WriteLine($"File Location: {Path.GetFullPath(filePath)}");
            }
            // Technical Constraint: Implement exception handling for file access errors
            catch (IOException ex)
            {
                Console.WriteLine($"File Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}