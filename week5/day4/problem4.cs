using System;
using System.IO; // Requirement: Necessary for DirectoryInfo class

namespace Dotnet_C_Demo.HandsOn_week5_day4
{
    internal class problem4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Project Directory Analyzer --- \n");

            try
            {
                // Requirement 1: Accept a root directory path from the user
                Console.Write("Enter the root directory path: ");
                string rootPath = Console.ReadLine();

                // Technical Constraint 1: Use DirectoryInfo class
                DirectoryInfo directory = new DirectoryInfo(rootPath);

                if (directory.Exists)
                {
                    // Requirement 2 & Technical Constraint 2: Use loops to iterate through directories
                    DirectoryInfo[] subDirectories = directory.GetDirectories();

                    Console.WriteLine($"\nAnalyzing root: {directory.FullName}");
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("{0,-30} | {1,-10}", "Folder Name", "File Count");
                    Console.WriteLine("--------------------------------------------------");

                    foreach (DirectoryInfo subDir in subDirectories)
                    {
                        // Requirement 3: Show the number of files present in each directory
                        int fileCount = subDir.GetFiles().Length;

                        // Expectations: Display folder names and file counts
                        Console.WriteLine("{0,-30} | {1,-10}", subDir.Name, fileCount);
                    }
                }
                else
                {
                    Console.WriteLine("Error: The specified root directory does not exist.");
                }
            }
            // Technical Constraint 3: Implement exception handling
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: You do not have permission to access one or more folders.");
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