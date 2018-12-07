using uit.ooad.Businesses;
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
                InputArgument<FloorCreateInput>(),
                context => FloorBusiness.Add(GetInput(context))
            );
        }
    }
}
