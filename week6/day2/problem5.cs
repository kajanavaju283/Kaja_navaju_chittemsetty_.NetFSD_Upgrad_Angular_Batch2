using System;

namespace Dotnet_C_Demo.HandsOn_week6_day2
{
    // Requirement 1 & 2: Class that ensures only one instance can be created
    public class ConfigurationManager
    {
        // Technical Constraint: Use static instance variable
        private static ConfigurationManager _instance;

        // Requirement 4: Store configuration values
        public string ApplicationName { get; private set; }
        public string Version { get; private set; }
        public string DatabaseConnectionString { get; private set; }

        // Technical Constraint: Use private constructor to prevent object creation using 'new'
        private ConfigurationManager()
        {
            // Simulating loading settings only once
            ApplicationName = "Inventory Management System";
            Version = "1.0.2";
            DatabaseConnectionString = "Server=myServer;Database=myDB;User=admin;";
            Console.WriteLine(">> [System] Configuration settings loaded from the source.");
        }

        // Requirement 3: Provide a GetInstance() method to retrieve the single object
        public static ConfigurationManager GetInstance()
        {
            // Technical Constraint: Basic level thread-safe implementation (optional but recommended)
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }

        public void DisplayConfiguration()
        {
            Console.WriteLine($"App Name: {ApplicationName}");
            Console.WriteLine($"Version : {Version}");
            Console.WriteLine($"DB Conn : {DatabaseConnectionString}");
        }
    }

    internal class problem5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Singleton Pattern: Configuration Manager --- \n");

            // Expectation: Access instance using ConfigurationManager.GetInstance()
            ConfigurationManager config1 = ConfigurationManager.GetInstance();
            config1.DisplayConfiguration();

            Console.WriteLine("\nRequesting configuration instance again...");
            ConfigurationManager config2 = ConfigurationManager.GetInstance();

            // Requirement 5: Demonstrate that multiple calls return the same instance
            if (ReferenceEquals(config1, config2))
            {
                Console.WriteLine("SUCCESS: Both config1 and config2 are the SAME instance.");
            }
            else
            {
                Console.WriteLine("FAILURE: Instances are different.");
            }

            Console.WriteLine("\nSingleton verified: The constructor was called only once.");
            Console.ReadKey();
        }
    }
}