using System;
using System.Linq;
using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;
using uit.ooad.Queries.Helper;

namespace uit.ooad.Queries.Mutation
{
    public class AuthenticationMutation : QueryType<Employee>
    {
        private static string ID = "id";
        private static string PASSWORD = "password";
        private static string NEW_PASSWORD = "newPassword";

        public AuthenticationMutation()
        {
            Field<StringGraphType>(
                "Login",
                "Đăng nhập nhân viên, trả về cái access token",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = ID },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = PASSWORD }
                ),
                context =>
                {
                    var id = _GetId<string>(context);
                    var password = context.GetArgument<string>(PASSWORD);

                    EmployeeBusiness.CheckLogin(id, password);

                    return AuthenticationHelper.TokenBuilder(id);
                }
            );

            Field<StringGraphType>(
                "ChangePassword",
                "Nhân viên tự đổi mật khẩu cho tài khoản của mình",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = PASSWORD },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = NEW_PASSWORD }
                ),
                context =>
                {
                    var id = AuthenticationHelper.GetEmployeeId(context);
                    var password = context.GetArgument<string>(PASSWORD);
                    var newPassword = context.GetArgument<string>(NEW_PASSWORD);

                    EmployeeBusiness.ChangePassword(id, password, newPassword);

                    return "Đổi mật khẩu thành công";
                }
            );

            Field<NonNullGraphType<StringGraphType>>(
                "InitializeDatabase",
                "Khởi tạo dữ liệu",
                resolve: context =>
                {
                    InitializeDatabase.InitializeDatabaseObject();
                    return "Tạo cơ sở dữ liệu thành công";
                }
            );
        }
    }
}
