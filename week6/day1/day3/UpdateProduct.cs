using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Dotnet_C_Demo.HandsOn_week6_day3
{
    internal class UpdateProduct
    {
        // Connection string for your local server
        static string connectionString = @"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("          UPDATE PRODUCT PRICE");
            Console.WriteLine("==============================================\n");

            try
            {
                // Get ID and New Price from the user
                Console.Write("Enter Product ID to update: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter New Price: ");
                decimal newPrice = decimal.Parse(Console.ReadLine());

                // Execute the update
                UpdatePrice(id, newPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[Input Error]: Please enter valid numbers for ID and Price.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void UpdatePrice(int id, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Call the update stored procedure
                    SqlCommand cmd = new SqlCommand("sp_UpdateProductPrice", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adding Parameters to the command
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    cmd.Parameters.AddWithValue("@Price", price);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the update actually happened
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\n[Success] Product price updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\n[Not Found] No product exists with the given ID.");
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