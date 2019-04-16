using GraphQL.Types;
using uit.hotel.Models;

namespace uit.hotel.ObjectTypes
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
                "Thông tin nhân viên đăng nhập",
                resolve: context => context.Source.Employee
            );
        }
    }

    public class AuthenticationObject
    {
        public Employee Employee { get; set; }
        public string Token { get; set; }
    }
}
