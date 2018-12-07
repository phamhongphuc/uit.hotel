using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace uit.ooad.Queries.Authentication
{
    public class AuthenticationHelper
    {
        private readonly IConfiguration Configuration;

        public AuthenticationHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string TokenBuilder(string id)
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
                    new Claim(ClaimTypes.Name, id)
                }
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}