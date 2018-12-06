using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class FloorMutation : QueryType<Floor>
    {
        public FloorMutation()
        {
            Field<FloorType>(
                _Creation,
                "Tạo và trả về một tầng mới",
                InputArgument<CreateFloorInputType>(),
                context =>
                {
                    return FloorBusiness.Add(
                        context.GetArgument<Floor>("input")
                    );
                }
            );
        }
    }

    public class CreateFloorInputType : InputType<Floor>
    {
        public CreateFloorInputType()
        {
            Name = _Creation;
            Field<NonNullGraphType<IntGraphType>>(nameof(Floor.Id));
            Field<NonNullGraphType<StringGraphType>>(nameof(Floor.Name));
        }
    }
}
