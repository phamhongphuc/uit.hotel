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
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "floorId" }
                    // new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "roomKindId" }
                ),
                context => RoomBusiness.Add(new Room
                {
                    Id = context.GetArgument<int>("id"),
                    Name = context.GetArgument<string>("name"),
                    Floor = FloorBusiness.Get(context.GetArgument<int>("floorId"))
                    // RoomKind = RoomKindBusiness.Get(context.GetArgument<string>("roomKindId"))
                })
            );
        }
    }
}
