using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Dotnet_C_Demo.HandsOn_week6_day3
{
    internal class DeleteProduct
    {
        // Your SQL Server Connection String
        static string connectionString = @"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("       DELETE PRODUCT RECORD");
            Console.WriteLine("==============================================\n");

            try
            {
                Console.Write("Enter Product ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                // Confirming before delete
                Console.Write($"Are you sure you want to delete Product ID {id}? (yes/no): ");
                string confirm = Console.ReadLine().ToLower();

                if (confirm == "yes")
                {
                    RemoveProduct(id);
                }
                else
                {
                    Console.WriteLine("\nDelete operation cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[Error]: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void RemoveProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Using Stored Procedure
                    SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adding Parameter
                    cmd.Parameters.AddWithValue("@ProductId", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"\n[Success] Product with ID {id} has been deleted.");
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