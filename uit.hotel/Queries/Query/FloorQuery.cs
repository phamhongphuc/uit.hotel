using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class FloorQuery : QueryType<Floor>
    {
        public FloorQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<FloorType>>>>(
                _List,
                "Trả về một danh sách các tầng",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetMap,
                    context => FloorBusiness.Get()
                )
            );

            Field<NonNullGraphType<FloorType>>(
                _Item,
                "Trả về thông tin một tầng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetMap,
                    context => FloorBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
