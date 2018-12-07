using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class RoomMutation : QueryType<Room>
    {
        public RoomMutation()
        {
            Field<RoomType>(
                _Creation,
                "Tạo và trả về một phòng mới",
                InputArgument<RoomCreateInput>(),
                context => RoomBusiness.Add(GetInput(context))
            );
        }
    }
}
