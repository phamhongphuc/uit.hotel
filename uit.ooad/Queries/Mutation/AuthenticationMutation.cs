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

                    return AuthenticationHelper.TokenBuilder(id);
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
