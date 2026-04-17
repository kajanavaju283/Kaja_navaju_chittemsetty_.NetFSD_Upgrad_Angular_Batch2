using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactAPI.Models;

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        static List<UserInfo> users = new();

        [HttpPost("register")]
        public IActionResult Register(UserInfo user)
        {
            users.Add(user);
            return Ok("User Registered");
        }

        [HttpPost("login")]
        public IActionResult Login(UserInfo login)
        {
            var user = users.FirstOrDefault(u => u.EmailId == login.EmailId && u.Password == login.Password);
            if (user == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_SECRET_KEY"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
