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
                InputArgument<CreateFloorInput>(),
                context => GetInput(context)
            );
        }
    }

    public class CreateFloorInput : InputType<Floor>
    {
        public CreateFloorInput()
        {
            Name = _Creation;
            Field<NonNullGraphType<IntGraphType>>(nameof(Floor.Id));
            Field<NonNullGraphType<StringGraphType>>(nameof(Floor.Name));
        }
    }
}
