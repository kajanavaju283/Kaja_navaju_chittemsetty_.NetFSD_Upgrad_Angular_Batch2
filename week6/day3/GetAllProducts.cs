using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Dotnet_C_Demo.HandsOn_week6_day3
{
    internal class GetAllProducts
    {
        // Connection string using your local server name
        static string connectionString = @"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("===========================================================");
            Console.WriteLine("                VIEW ALL PRODUCT RECORDS");
            Console.WriteLine("===========================================================\n");

            FetchAndDisplayProducts();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void FetchAndDisplayProducts()
        {
            // Using statement ensures the connection is closed automatically
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Calling the Stored Procedure
                    SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    // SqlDataReader is used to read data row by row
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Printing Table Headers
                        Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-10}", "ID", "Product Name", "Category", "Price");
                        Console.WriteLine(new string('-', 65));

                        while (reader.Read())
                        {
                            // Accessing data using column names
                            Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-10:F2}",
                                reader["ProductId"],
                                reader["ProductName"],
                                reader["Category"],
                                reader["Price"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records found in the Products table.");
                    }
                }
                catch (SqlException ex)
                {
                    // Handling Database related errors
                    Console.WriteLine("\n[Database Error]: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n[General Error]: " + ex.Message);
                }
            }
        }
    }
}