using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Dotnet_C_Demo.HandsOn_week6_day3
{
    // 1. Product Entity Class
    public class ProductItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    internal class AddProducts
    {
        // Connection string updated with your Server Name from the photo
        // Note: Change 'master' to your specific database name if you created a new one.
        static string connectionString = @"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("--- ADO.NET Product Management System --- \n");

            try
            {
                // Taking Input from User
                ProductItem newProduct = new ProductItem();

                Console.Write("Enter Product Name: ");
                newProduct.ProductName = Console.ReadLine();

                Console.Write("Enter Category: ");
                newProduct.Category = Console.ReadLine();

                Console.Write("Enter Price: ");
                newProduct.Price = decimal.Parse(Console.ReadLine());

                // Execute Insert Operation
                InsertProduct(newProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[Input Error]: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void InsertProduct(ProductItem p)
        {
            // Requirement: Proper Resource Handling using 'using'
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Requirement: Use Stored Procedure
                    SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Requirement: Use SqlParameters to prevent SQL Injection
                    cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                    cmd.Parameters.AddWithValue("@Category", p.Category);
                    cmd.Parameters.AddWithValue("@Price", p.Price);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Executes the Stored Procedure

                    Console.WriteLine("\n[Success] Product details saved to SQL Server successfully!");
                }
                catch (SqlException ex)
                {
                    // Requirement: Exception Handling for DB issues
                    Console.WriteLine("\n[Database Error]: " + ex.Message);
                }
            }
        }
    }
}