using System;

namespace Dotnet_C_Demo.HandsOn_week5_day1
{
    internal class problem2
    {
        // Technical Constraint: Only array-based stack implementation
        static string[] stack = new string[10];
        static int top = -1;

        // Requirement: Support push (add action)
        static void Push(string action)
        {
            if (top >= stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow! Cannot add more actions.");
            }
            else
            {
                stack[++top] = action;
                Console.WriteLine($"Action Added: {action}");
            }
        }

        // Requirement: Support pop (undo action)
        static void Pop()
        {
            // Technical Constraint: Handle empty stack condition
            if (top == -1)
            {
                Console.WriteLine("Nothing to undo! Stack is empty.");
            }
            else
            {
                Console.WriteLine($"Undo Performed: {stack[top--]} removed.");
            }
        }

        // Requirement: Display current state after each operation
        static void DisplayCurrentState()
        {
            if (top == -1)
            {
                Console.WriteLine("Current State: Empty");
            }
            else
            {
                Console.WriteLine($"Current State After Operations: {stack[top]}");
            }
            Console.WriteLine("-------------------------------------------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Text Editor Undo System (LIFO) --- \n");

            // Sample Input: Actions: Type A, Type B, Type C
            Push("Type A");
            DisplayCurrentState();

            Push("Type B");
            DisplayCurrentState();

            Push("Type C");
            DisplayCurrentState();

            // Sample Input: Undo, Undo
            Pop();
            DisplayCurrentState();

            Pop();
            DisplayCurrentState();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
