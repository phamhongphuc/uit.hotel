using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class AuthenticationMutation : QueryType<Employee>
    {
        private readonly IConfiguration Configuration;

        public AuthenticationMutation(IConfiguration configuration)
        {
            Configuration = configuration;

            Field<StringGraphType>(
                "Login",
                "Đăng nhập nhân viên, trả về cái access token",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
                ),
                context =>
                {
                    var id = context.GetArgument<string>("id");
                    return TokenBuilder(id);
                }
            );
        }

        private string TokenBuilder(string id)
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
