using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class RoomKindQuery : QueryType<RoomKind>
    {
        public RoomKindQuery()
        {
            Field<ListGraphType<RoomKindType>>(
                _List,
                "Trả về một danh sách các loại phòng",
                resolve: context => RoomKindBusiness.Get()
            );
            Field<RoomKindType>(
                nameof(RoomKind),
                "Trả về thông tin của một loại phòng",
                IdArgument(),
                context => RoomKindBusiness.Get(GetId<int>(context))
            );
        }
    }
}
