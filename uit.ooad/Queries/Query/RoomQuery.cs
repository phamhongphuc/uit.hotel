using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Query
{
    public class RoomQuery : RootQueryGraphType
    {
        public RoomQuery()
        {
            Field<ListGraphType<RoomType>>(
                GetList(nameof(Room)),
                "Trả về một danh sách các phòng",
                resolve: context => RoomBusiness.Get()
            );
            Field<RoomType>(
                nameof(Room),
                "Trả về thông tin của một phòng",
                new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                context => RoomBusiness.Get(context.GetArgument<int>("id"))
            );
        }
    }
}
