using Microsoft.AspNetCore.Mvc;

namespace Week7_day2_handson.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your valuable feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            
            return View("Index");
        }
    }
}
