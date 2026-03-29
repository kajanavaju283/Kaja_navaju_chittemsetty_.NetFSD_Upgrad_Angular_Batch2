using System;
using System.IO; // Requirement: Necessary for DriveInfo class

namespace Dotnet_C_Demo.HandsOn_week5_day4
{
    internal class problem5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- System Drive Storage Monitor --- \n");

            // Requirement 1 & Technical Constraint 1: Retrieve all system drives using DriveInfo
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            // Technical Constraint 3: Use loops to process multiple drives
            foreach (DriveInfo drive in allDrives)
            {
                // Technical Constraint 2: Ensure the drive is ready before accessing properties
                if (drive.IsReady)
                {
                    // Requirement 2: Display drive name, type, total size, and free space
                    double totalSizeGB = drive.TotalSize / (1024.0 * 1024 * 1024);
                    double freeSpaceGB = drive.TotalFreeSpace / (1024.0 * 1024 * 1024);

                    // Requirement 3: Calculate percentage of free space
                    double freePercentage = (freeSpaceGB / totalSizeGB) * 100;

                    Console.WriteLine($"Drive Name      : {drive.Name}");
                    Console.WriteLine($"Drive Type      : {drive.DriveType}");
                    Console.WriteLine($"Total Size      : {totalSizeGB:F2} GB");
                    Console.WriteLine($"Available Space : {freeSpaceGB:F2} GB ({freePercentage:F1}%)");

                    // Requirement 3 & Expectations: Display a warning if free space is below 15%
                    if (freePercentage < 15)
                    {
                        Console.WriteLine("!!! WARNING: Low disk space detected on this drive !!!");
                    }

                    Console.WriteLine("--------------------------------------------------");
                }
            }

            Console.WriteLine("\nDrive monitoring complete.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}