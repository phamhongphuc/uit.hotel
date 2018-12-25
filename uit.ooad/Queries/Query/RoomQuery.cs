using System.Collections.Generic;
using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class RoomQuery : QueryType<Room>
    {
        public RoomQuery()
        {
            Field<ListGraphType<RoomType>>(
                _List,
                "Trả về một danh sách các phòng",
                resolve: _CheckPermission<IEnumerable<Room>>(
                    p => p.PermissionGetRooms,
                     context => RoomBusiness.Get()
                )
            );
            Field<RoomType>(
                _Item,
                "Trả về thông tin của một phòng",
                _IdArgument(),
                context => RoomBusiness.Get(_GetId<int>(context))
            );
        }
    }
}
