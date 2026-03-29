using System;
using System.IO; // Requirement: Necessary for FileInfo and Directory classes

namespace Dotnet_C_Demo.HandsOn_week5_day4
{
    internal class problem2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- File Properties Auditor --- \n");

            // Requirement 1: Accept a folder path from the user
            Console.Write("Enter the full folder path: ");
            string folderPath = Console.ReadLine();

            // Technical Constraint 2: Handle invalid directory paths
            if (Directory.Exists(folderPath))
            {
                // Retrieve all file paths from the directory
                string[] files = Directory.GetFiles(folderPath);

                // Requirement 3: Count and display total number of files
                Console.WriteLine($"\nTotal files found: {files.Length}");
                Console.WriteLine("--------------------------------------------------");

                foreach (string filePath in files)
                {
                    // Technical Constraint 1: Use FileInfo class
                    FileInfo fileInfo = new FileInfo(filePath);

                    // Requirement 2: Display file name, size, and creation date
                    Console.WriteLine($"File Name    : {fileInfo.Name}");
                    Console.WriteLine($"File Size    : {fileInfo.Length} bytes");
                    Console.WriteLine($"Creation Date: {fileInfo.CreationTime}");
                    Console.WriteLine("--------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Error: The specified directory path does not exist.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}