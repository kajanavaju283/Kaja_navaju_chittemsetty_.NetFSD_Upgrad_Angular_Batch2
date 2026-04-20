using Microsoft.AspNetCore.Mvc;
using CategoryService.Models;
using CategoryService.Services;

namespace CategoryService.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryServiceClass _service;

        public CategoriesController(CategoryServiceClass service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            return Ok(await _service.Add(category));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            return Ok(await _service.Update(category));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
