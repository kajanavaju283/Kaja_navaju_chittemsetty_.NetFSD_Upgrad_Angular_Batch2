using System;

namespace Dotnet_C_Demo.HandsOn_week6_day2
{
    // Requirement: Students must implement an Interface
    // Technical Constraint: Use interface-based design
    public interface INotification
    {
        // Requirement: Method named Send accepting a string message
        void Send(string message);
    }

    // Requirement: Classes implementing INotification

    // Email Notification Service
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($">> [Email] Sending secure email: '{message}'");
        }
    }

    // SMS Notification Service
    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($">> [SMS] Sending text message: '{message}'");
        }
    }

    // Push Notification Service
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($">> [Push] Sending app notification: '{message}'");
        }
    }

    // Requirement: Factory Class named NotificationFactory
    // Technical Constraint: Use Factory Pattern to create objects
    public class NotificationFactory
    {
        // Requirement: Method named CreateNotification(string type)
        // Example uses: CreateNotification("email"), ("sms"), ("push")
        public INotification CreateNotification(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();
                case "sms":
                    return new SMSNotification();
                case "push":
                    return new PushNotification();
                default:
                    // Learning Outcome: Handling unexpected or unknown creation requests
                    throw new ArgumentException($"Notification type '{type}' is not supported.");
            }
        }
    }

    // Technical Constraint: Language: C# Console Application
    internal class problem6
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Factory Pattern: Notification Service System --- \n");

            // Expectation: Technical Constraint: Client should NOT instantiate concrete classes directly using 'new'
            // Good Practice: In real-world, object creation from usage
            NotificationFactory factory = new NotificationFactory();

            // expectations: Demonstrate usage with different examples

            // Scenario 1: Sending an Email
            Console.WriteLine("Requesting: email");
            INotification emailNotify = factory.CreateNotification("email");
            emailNotify.Send("Welcome to our service!"); // expectation matched: var.Send("Welcome to our service!")

            // Scenario 2: Sending an SMS
            Console.WriteLine("\nRequesting: sms");
            INotification smsNotify = factory.CreateNotification("sms");
            smsNotify.Send("Your OTP is 123456.");

            // Scenario 3: Sending a Push Notification
            Console.WriteLine("\nRequesting: push");
            INotification pushNotify = factory.CreateNotification("push");
            pushNotify.Send("You have a new friend request.");

            // Scenario 4: Attempting to use an invalid type
            // Console.WriteLine("\nRequesting: invalid_type");
            // INotification invalid = factory.CreateNotification("invalid_type"); // This will throw an exception

            Console.WriteLine("\nFactory Pattern verified: Objects created via the central factory.");
            Console.ReadKey();
        }
    }
}