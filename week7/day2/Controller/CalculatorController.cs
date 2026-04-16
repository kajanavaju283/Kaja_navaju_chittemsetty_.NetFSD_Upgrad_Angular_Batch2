using Microsoft.AspNetCore.Mvc;

namespace Week7_day2_handson.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        // POST: handle form submission
        [HttpPost("add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            // store result using ViewData
            ViewData["Result"] = result;

            // return same view with result
            return View("Index");
        }
    }
}
