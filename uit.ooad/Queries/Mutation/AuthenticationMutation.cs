using GraphQL.Types;
using uit.ooad.Models;
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
                    var id = context.GetArgument<string>("id");

                    return AuthenticationHelper.TokenBuilder(id);
                }
            );
        }
    }
}
