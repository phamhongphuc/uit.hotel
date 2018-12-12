using System;
using System.Linq;
using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class AuthenticationMutation : QueryType<Employee>
    {
        public AuthenticationMutation()
        {
            Field<StringGraphType>(
                "Login",
                "Đăng nhập nhân viên, trả về cái access token",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
                ),
                context =>
                {
                    var id = GetId<string>(context);
                    var password = context.GetArgument<string>("password");
                    EmployeeBusiness.CheckLogin(id, password);

                    return AuthenticationHelper.TokenBuilder(id);
                }
            );

            Field<StringGraphType>(
                "ChangePassword",
                "Nhân viên tự đổi mật khẩu cho tài khoản của mình",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "newPassword" }
                ),
                context =>
                {
                    var id = AuthenticationHelper.GetEmployeeId(context);
                    var password = context.GetArgument<string>("password");
                    var newPassword = context.GetArgument<string>("newPassword");
                    EmployeeBusiness.ChangePassword(id, password, newPassword);
                    return "Đổi mật khẩu thành công";
                }
            );

            Field<NonNullGraphType<EmployeeType>>(
                "CreateAdminIfNotExists",
                "Khởi tạo tài khoản admin",
                resolve: context =>
                {
                    EmployeeBusiness.CreateAdminIfNotExists();
                    return EmployeeBusiness.Get("admin");
                }
            );
        }
    }
}
