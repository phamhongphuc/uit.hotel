using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Interface;

namespace uit.ooad.Queries.Mutation
{
    public class FloorMutation : RootQueryGraphType<Floor>
    {
        public FloorMutation()
        {
            Field<FloorType>(
                _Creation,
                "Tạo và trả về một tầng mới",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<CreateFloorInputType>> { Name = "input" }
                ),
                context =>
                {
                    return FloorBusiness.Add(
                        context.GetArgument<Floor>("input")
                    );
                }
            );
        }
    }

    public class CreateFloorInputType : RootInputGraphType<Floor>
    {
        public CreateFloorInputType()
        {
            Name = _Creation;
            Field<NonNullGraphType<IntGraphType>>(nameof(Floor.Id));
            Field<NonNullGraphType<StringGraphType>>(nameof(Floor.Name));
        }
    }
}
