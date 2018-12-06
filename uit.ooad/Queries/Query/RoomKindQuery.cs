using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Query
{
    public class RoomKindQuery : RootQueryGraphType
    {
        public RoomKindQuery()
        {
            Field<ListGraphType<RoomKindType>>(
                GetList(nameof(RoomKind)),
                "Trả về một danh sách các loại phòng",
                resolve: context => RoomKindBusiness.Get()
            );
            Field<RoomKindType>(
                nameof(RoomKind),
                "Trả về thông tin của một loại phòng",
                new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<IntGraphType> { Name = "numberOfBeds" },
                    new QueryArgument<IntGraphType> { Name = "amountOfPeople" },
                    new QueryArgument<IntGraphType> { Name = "priceByDate" }
                ),
                resolve: context => RoomKindBusiness.Get(context.GetArgument<int>("id"))
            );
        }
    }
}