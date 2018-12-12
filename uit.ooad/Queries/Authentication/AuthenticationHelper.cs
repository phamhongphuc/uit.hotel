using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using uit.ooad.Businesses;
using uit.ooad.GraphQLHelper;
using uit.ooad.Models;

namespace uit.ooad.Queries.Authentication
{
    public static class AuthenticationHelper
    {
        private static IConfiguration Configuration;

        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static string TokenBuilder(string id)
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

        public static void HasPermission(ResolveFieldContext<object> context, Func<Position, bool> getPermission)
        {
            var employeeId = GetEmployeeId(context);

            var employee = EmployeeBusiness.Get(employeeId);
            if (employee == null) throw new Exception("Không tim thấy tên đăng nhập trong hệ thống");

            var position = employee.Position;
            if (position == null) new Exception("Tài khoản lỗi, vui lòng liên hệ quản trị viên");

            var hasPermission = getPermission(position);
            if (!hasPermission) throw new Exception("Người dùng không có quyền thực hiện thao tác này");
        }

        public static string GetEmployeeId(ResolveFieldContext<object> context)
        {
            if (!(context.UserContext is GraphQLUserContext userContext)) throw new Exception("Lỗi không xác định");

            var employeeId = userContext.User.FindFirst(u => u.Type == ClaimTypes.Name);
            if (employeeId == null) throw new Exception("Không tìm thấy tên đăng nhập");
            return employeeId.Value;
        }
    }
}
