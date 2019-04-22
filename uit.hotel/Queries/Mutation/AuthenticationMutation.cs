using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Queries.Mutation
{
    public class AuthenticationMutation : QueryType<Employee>
    {
        private static readonly string ID = "id";
        private static readonly string PASSWORD = "password";
        private static readonly string NEW_PASSWORD = "newPassword";

        public AuthenticationMutation()
        {
            Field<NonNullGraphType<AuthenticationType>>(
                "Login",
                "Đăng nhập mới",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = ID },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = PASSWORD }
                ),
                context =>
                {
                    var id = _GetId<string>(context);
                    var password = context.GetArgument<string>(PASSWORD);
                    return EmployeeBusiness.GetAuthenticationObject(id, password);
                }
            );

            Field<NonNullGraphType<EmployeeType>>(
                "CheckLogin",
                "Kiểm tra đăng nhập",
                resolve: context =>
                {
                    var employee = AuthenticationHelper.GetEmployee(context);
                    EmployeeBusiness.CheckIsActive(employee);
                    return employee;
                }
            );

            Field<NonNullGraphType<StringGraphType>>(
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

            //TODO: Remove this mutation
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
