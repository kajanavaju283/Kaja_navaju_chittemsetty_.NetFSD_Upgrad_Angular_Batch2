using System;

namespace Dotnet_C_Demo.HandsOn_week5_day4
{
    internal class problem3
    {
        // Requirement 2 & Technical Constraint 1: Method returning multiple values using a Tuple
        static (double Sales, int Rating) GetEmployeeData()
        {
            // Requirement 1 & Technical Constraint 4: Input validation
            Console.Write("Enter Monthly Sales Amount: ");
            double sales = double.Parse(Console.ReadLine());

            Console.Write("Enter Customer Feedback Rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            return (sales, rating);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Employee Performance Evaluator --- \n");

            // Requirement 1: Accept Employee Name
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            // Calling the tuple method
            var data = GetEmployeeData();

            // Requirement 3 & Technical Constraint 2: Use Pattern Matching (Switch Expression)
            // Technical Constraint 3: Avoid multiple nested if-else statements
            string performanceCategory = data switch
            {
                { Sales: >= 100000, Rating: >= 4 } => "High Performer",
                { Sales: >= 50000, Rating: >= 3 } => "Average Performer",
                _ => "Needs Improvement" // All other cases
            };

            // Requirement 4: Display the formatted output
            Console.WriteLine("\n--- Performance Report ---");
            Console.WriteLine($"Employee Name     : {name}");
            Console.WriteLine($"Sales Amount      : {data.Sales}");
            Console.WriteLine($"Rating            : {data.Rating}");
            Console.WriteLine($"Performance Category: {performanceCategory}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}