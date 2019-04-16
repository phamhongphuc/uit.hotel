using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class PositionQuery : QueryType<Position>
    {
        public PositionQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PositionType>>>>(
                _List,
                "Trả về một danh sách các chức vụ",
                resolve: _CheckPermission_List(
                    p => p.PermissionManagePosition,
                    context => PositionBusiness.Get()
                )
            );

            Field<NonNullGraphType<PositionType>>(
                _Item,
                "Trả về thông tin một chức vụ",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionManagePosition,
                    context => PositionBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
