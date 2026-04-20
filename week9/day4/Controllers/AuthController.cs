using Microsoft.AspNetCore.Mvc;
using AuthService.Services;
using AuthService.Models;


namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthServiceClass _service;

        public AuthController(AuthServiceClass service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            return Ok(_service.Register(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var token = _service.Login(dto.Email, dto.Password);

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(token);
        }
    }
}