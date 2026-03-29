using System;

namespace Dotnet_C_Demo.HandsOn_week5_day1
{
    // Requirement 1: Create Node structure with employee ID and name
    public class EmployeeNode
    {
        public int Id;
        public string Name;
        public EmployeeNode Next; // Technical Constraint: Must implement singly linked list

        public EmployeeNode(int id, string name)
        {
            Id = id;
            Name = name;
            Next = null;
        }
    }

    public class EmployeeLinkedList
    {
        private EmployeeNode head;

        // Requirement 2: Implement insertion at the end
        public void InsertAtEnd(int id, string name)
        {
            EmployeeNode newNode = new EmployeeNode(id, name);
            if (head == null)
            {
                head = newNode;
                return;
            }
            EmployeeNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }

        // Requirement 3: Implement deletion by employee ID
        public void DeleteById(int id)
        {
            if (head == null) return;

            if (head.Id == id)
            {
                head = head.Next;
                return;
            }

            EmployeeNode temp = head;
            while (temp.Next != null && temp.Next.Id != id)
            {
                temp = temp.Next;
            }

            if (temp.Next != null)
            {
                temp.Next = temp.Next.Next;
            }
        }

        // Requirement 4: Traverse and display employee list
        public void DisplayEmployees()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }
            EmployeeNode temp = head;
            while (temp != null)
            {
                Console.WriteLine($"ID: {temp.Id}, Name: {temp.Name}");
                temp = temp.Next;
            }
        }
    }

    internal class problem3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Employee Management (Linked List) --- \n");

            EmployeeLinkedList list = new EmployeeLinkedList();

            // Sample Input: Insert (101, John), (102, Sara), (103, Mike)
            list.InsertAtEnd(101, "John");
            list.InsertAtEnd(102, "Sara");
            list.InsertAtEnd(103, "Mike");

            Console.WriteLine("Initial Employee List:");
            list.DisplayEmployees();

            // Sample Input: Delete 102
            Console.WriteLine("\nDeleting Employee with ID 102...");
            list.DeleteById(102);

            // Sample Output
            Console.WriteLine("\nEmployee List After Deletion:");
            list.DisplayEmployees();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}