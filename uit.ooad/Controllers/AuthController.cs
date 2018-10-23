using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace uit.ooad.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public AuthController(IConfiguration configuration) => Configuration = configuration;

        [HttpPost]
        public IActionResult PostApiAuth(string username = "admin", string password = "admin")
        {
            IActionResult result = Unauthorized();

            if (username.Equals(password))
            {
                result = base.Ok(new
                {
                    access_token = TokenBuilder(username)
                });
            }

            return result;
        }

        private string TokenBuilder(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Configuration["JWT:issuer"],
                Configuration["JWT:audience"],
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(3),
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
