using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Week7_day2_handson.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        [HttpGet("")]
        [HttpGet("/")]
        public IActionResult Index()
        {
            var products = GetProducts();
            ViewBag.Products = products;

            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(string name, int price, int quantity)
        {
            var products = GetProducts();

            var product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            products.Add(product);

            HttpContext.Session.SetString("products",
                JsonSerializer.Serialize(products));

            ViewBag.Products = products;

            return View("Index");
        }

        private List<Product> GetProducts()
        {
            var data = HttpContext.Session.GetString("products");

            if (data == null)
            {
                return new List<Product>();
            }

            return JsonSerializer.Deserialize<List<Product>>(data);
        }
    }
}
