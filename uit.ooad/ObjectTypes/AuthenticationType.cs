using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
{
    public class AuthenticationType : ObjectGraphType<AuthenticationObject>
    {
        public AuthenticationType()
        {
            Name = nameof(AuthenticationObject);
            Description = "Một đối tượng đăng nhập";

            Field(x => x.Token).Description("Token đăng nhập");
            Field<NonNullGraphType<EmployeeType>>(
                nameof(AuthenticationObject.Employee),
                resolve: context => context.Source.Employee,
                description: "Thông tin nhân viên đăng nhập");
        }
    }

    public class AuthenticationObject
    {
        public Employee Employee { get; set; }
        public string Token { get; set; }
    }
}