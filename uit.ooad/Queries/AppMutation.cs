using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation()
        {
            Field<FloorType>(
                "floor",
                "Tạo và trả về một tầng mới",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                ),
                context => FloorBusiness.Add(new Floor
                {
                    Id = context.GetArgument<int>("id"),
                    Name = context.GetArgument<string>("name")
                })
            );

            Field<EmployeeType>(
                "createEmployee",
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
