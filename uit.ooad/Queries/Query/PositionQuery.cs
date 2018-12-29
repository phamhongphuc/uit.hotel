using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class PositionQuery : QueryType<Position>
    {
        public PositionQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PositionType>>>>(
                _List,
                "Trả về một danh sách các chức vụ",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetPosition,
                    context => PositionBusiness.Get()
                )
            );
            
            Field<NonNullGraphType<PositionType>>(
                _Item,
                "Trả về thông tin một chức vụ",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetPosition,
                    context => PositionBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
