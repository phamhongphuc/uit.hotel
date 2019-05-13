using System;
using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Queries.Mutation
{
    public class InitializeMutation : QueryType<Employee>
    {
        private static readonly string PASSWORD = "password";
        private static readonly string EMAIL = "email";

        public InitializeMutation()
        {
            Field<NonNullGraphType<StringGraphType>>(
                "InitializeAdminAccount",
                "Khởi tạo tài khoản admin",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = EMAIL },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = PASSWORD }
                ),
                context =>
                {
                    var email = context.GetArgument<string>(EMAIL);
                    var password = context.GetArgument<string>(PASSWORD);
                    InitializeBusiness.Initialize(new Employee
                    {
                        Email = email,
                        Password = password,
                    });

                    return "Khởi tạo tài khoản admin thành công";
                }
            );
        }
    }
}
