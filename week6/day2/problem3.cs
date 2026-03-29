using System;

namespace Dotnet_C_Demo.HandsOn_week6_day2
{
    // Requirement 1: Create a base class
    public abstract class Shape
    {
        // Requirement 3: Define an abstract method for area calculation
        public abstract double CalculateArea();
    }

    // Requirement 2: Create derived classes

    // Rectangle Implementation
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        // Technical Constraint: Use method overriding
        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    // Circle Implementation
    public class Circle : Shape
    {
        public double Radius { get; set; }

        // Technical Constraint: Derived classes must not break base class behavior
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    internal class problem3
    {
        // Requirement 4: A method should accept a Shape object and calculate area
        // This demonstrates substitutability (LSP)
        static void PrintArea(Shape shape)
        {
            Console.WriteLine($"The area of the shape is: {shape.CalculateArea():F2}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- LSP: Shape Area Calculator --- \n");

            // Expectations: Demonstrate that the program works with different objects

            // Using a Rectangle object as a Shape
            Shape myRect = new Rectangle { Width = 5, Height = 10 };
            Console.Write("Rectangle: ");
            PrintArea(myRect);

            // Using a Circle object as a Shape
            Shape myCircle = new Circle { Radius = 7 };
            Console.Write("Circle: ");
            PrintArea(myCircle);

            Console.WriteLine("\nLSP verified: Both Rectangle and Circle successfully substituted 'Shape'.");
            Console.ReadKey();
        }
    }
}