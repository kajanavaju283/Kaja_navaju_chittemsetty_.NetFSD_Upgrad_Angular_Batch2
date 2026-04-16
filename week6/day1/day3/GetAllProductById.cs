using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Dotnet_C_Demo.HandsOn_week6_day3
{
    internal class GetAllProductById
    {
        // Connection string for your local database
        static string connectionString = @"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("          SEARCH PRODUCT BY ID");
            Console.WriteLine("==============================================\n");

            try
            {
                Console.Write("Enter the Product ID you want to find: ");
                int id = int.Parse(Console.ReadLine());

                FindProduct(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[Input Error]: Please enter a valid numeric ID.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void FindProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Requirement: Call the search stored procedure
                    SqlCommand cmd = new SqlCommand("sp_GetProductById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Displaying the specific record found
                        Console.WriteLine("\n--- Product Found ---");
                        Console.WriteLine($"Product ID:   {reader["ProductId"]}");
                        Console.WriteLine($"Name:         {reader["ProductName"]}");
                        Console.WriteLine($"Category:     {reader["Category"]}");
                        Console.WriteLine($"Price:        {reader["Price"]:C}");
                    }
                    else
                    {
                        Console.WriteLine($"\n[Not Found] No product exists with ID: {id}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("\n[Database Error]: " + ex.Message);
                }
            }
        }
    }
}