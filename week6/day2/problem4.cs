using System;

namespace Dotnet_C_Demo.HandsOn_week6_day2
{
    // Requirement 1: Create specific interfaces instead of one large interface

    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IFax
    {
        void Fax();
    }

    // Requirement 2: Implement Classes based on specific needs

    // Basic Printer: Only needs the Print functionality
    // Technical Constraint: Does not implement unnecessary methods (Scan/Fax)
    public class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Basic Printer: Printing document...");
        }
    }

    // Advanced Printer: Needs all functionalities (Print, Scan, Fax)
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing in high quality...");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning document to PDF...");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending Fax...");
        }
    }

    internal class problem4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- ISP: Office Printer System --- \n");

            // Expectations: Demonstrate that classes only have methods they require

            Console.WriteLine("Testing Basic Printer:");
            BasicPrinter basic = new BasicPrinter();
            basic.Print();
            // basic.Scan(); // This would cause a compile error, which is correct for ISP!

            Console.WriteLine("\nTesting Advanced Printer:");
            AdvancedPrinter advanced = new AdvancedPrinter();
            advanced.Print();
            advanced.Scan();
            advanced.Fax();

            Console.WriteLine("\nISP verified: Interfaces are segregated into smaller pieces.");
            Console.ReadKey();
        }
    }
}