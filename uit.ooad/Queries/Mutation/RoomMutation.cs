using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Mutation
{
    public class RoomMutation : RootQueryGraphType
    {
        public RoomMutation()
        {
            Field<RoomType>(
                GetCreation(nameof(Room)),
                "Tạo và trả về một phòng mới",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }
                    // new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "floorId" },
                    // new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "roomKindId" }
                ),
                context => RoomBusiness.Add(new Room
                {
                    Id = context.GetArgument<int>("id"),
                    Name = context.GetArgument<string>("name")
                    // Floor = FloorBusiness.Get(context.GetArgument<int>("floorId")),
                    // RoomKind = RoomKindBusiness.Get(context.GetArgument<string>("roomKindId"))
                })
            );
        }
    }
}
