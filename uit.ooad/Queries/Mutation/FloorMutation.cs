using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Mutation
{
    public class FloorMutation : RootQueryGraphType
    {
        public FloorMutation()
        {
            Field<FloorType>(
                GetCreation<Floor>(),
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
        }
    }
}
