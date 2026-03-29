using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet_C_Demo.HandsOn_week5_day3
{
    // Product class for logic implementation
    public class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double Mrp { get; set; }
    }

    internal class problem1
    {
        static void Main(string[] args)
        {
            // Sample data based on your requirements
            List<Product> products = new List<Product>
            {
                new Product { ProductCode = 101, ProductName = "Soap", Category = "FMCG", Mrp = 25 },
                new Product { ProductCode = 105, ProductName = "Rice", Category = "Grain", Mrp = 65 },
                new Product { ProductCode = 102, ProductName = "Shampoo", Category = "FMCG", Mrp = 120 },
                new Product { ProductCode = 104, ProductName = "Wheat", Category = "Grain", Mrp = 45 },
                new Product { ProductCode = 103, ProductName = "Toothpaste", Category = "FMCG", Mrp = 20 }
            };

            // 1 & 2. Filtering by Category
            var fmcgProducts = products.Where(p => p.Category == "FMCG");
            var grainProducts = products.Where(p => p.Category == "Grain");

            // 3, 4, 5. Ascending Sorting
            var sortByCode = products.OrderBy(p => p.ProductCode);
            var sortByCategory = products.OrderBy(p => p.Category);
            var sortByMrpAsc = products.OrderBy(p => p.Mrp);

            // 6. Descending Sorting
            var sortByMrpDesc = products.OrderByDescending(p => p.Mrp);

            // 7 & 8. Grouping Tasks
            var groupByCat = products.GroupBy(p => p.Category);
            var groupByMrp = products.GroupBy(p => p.Mrp);

            // 9. Highest price in FMCG category
            var maxFmcg = products.Where(p => p.Category == "FMCG").Max(p => p.Mrp);

            // 10, 11, 12, 13. Aggregation (Counts & Prices)
            int totalCount = products.Count();
            int fmcgCount = products.Count(p => p.Category == "FMCG");
            double maxPrice = products.Max(p => p.Mrp);
            double minPrice = products.Min(p => p.Mrp);

            // 14 & 15. All/Any checks for Mrp Rs.30
            bool allBelow30 = products.All(p => p.Mrp < 30);
            bool anyBelow30 = products.Any(p => p.Mrp < 30);

            // Printing Results for Verification
            Console.WriteLine($"Total Products: {totalCount}");
            Console.WriteLine($"Max Price in FMCG: {maxFmcg}");
            Console.WriteLine($"Is any product below Rs.30? {anyBelow30}");

            Console.ReadKey();
        }
    }
}