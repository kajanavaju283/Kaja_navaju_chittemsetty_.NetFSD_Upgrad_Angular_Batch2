using System;
using System.Collections.Generic;
using System.Linq; // Essential for array processing methods

namespace Dotnet_C_Demo.HandsOn_week5_day1
{
    internal class problem1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Student Score Analyzer ---");

            // Requirement 1: Store student marks in an array
            int[] marks = { 78, 85, 90, 67, 88 };
            int threshold = 80;

            // Requirement 2 & Technical Constraints: Use array methods for processing
            // Calculate total using .Sum() (alternative to reduce)
            int totalMarks = marks.Sum();

            // Calculate average
            double averageMarks = marks.Average();

            // Find highest score
            int highestScore = marks.Max();

            // Requirement: Count students scoring above threshold (filter)
            int studentsAboveThreshold = marks.Count(m => m > threshold);

            // Requirement 3: Store subject-wise highest marks using a Map (Dictionary)
            // Example data for mapping
            Dictionary<string, int> subjectHighest = new Dictionary<string, int>
            {
                { "Maths", 90 },
                { "Science", 85 },
                { "English", 78 }
            };

            // Display Output results
            Console.WriteLine($"\nTotal Marks: {totalMarks}");
            Console.WriteLine($"Average Marks: {averageMarks:F1}");
            Console.WriteLine($"Students above {threshold}: {studentsAboveThreshold}");
            Console.WriteLine($"Highest Score: {highestScore}");

            Console.WriteLine("\n--- Subject-wise Highest (Dictionary) ---");
            foreach (var entry in subjectHighest)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}