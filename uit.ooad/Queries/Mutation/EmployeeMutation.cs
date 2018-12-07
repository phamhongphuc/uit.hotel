using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class EmployeeeMutation : QueryType<Employee>
    {
        public EmployeeeMutation()
        {
            Field<EmployeeType>(
                _Creation,
                "Tạo và trả về một nhân viên mới",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
                ),
                context => EmployeeBusiness.Add(new Employee
                {
                    Id = context.GetArgument<string>("id"),
                    Name = context.GetArgument<string>("name"),
                    Password = context.GetArgument<string>("password")
                })
            );
        }
    }
}
