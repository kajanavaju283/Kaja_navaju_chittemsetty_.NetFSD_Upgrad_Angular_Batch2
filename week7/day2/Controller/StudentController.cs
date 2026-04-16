using Microsoft.AspNetCore.Mvc;

namespace Week7_day2_handson.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(string name, int age, string course)
        {
            return RedirectToAction("Display", new
            {
                name = name,
                age = age,
                course = course
            });
        }

        [HttpGet("display")]
        public IActionResult Display(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}
