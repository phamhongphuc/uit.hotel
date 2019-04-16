using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class PatronKindQuery : QueryType<PatronKind>
    {
        public PatronKindQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PatronKindType>>>>(
                _List,
                "Trả về một danh sách các loại khách hàng có trong hệ thống",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetPatron,
                    context => PatronKindBusiness.Get()
                )
            );

            Field<NonNullGraphType<PatronKindType>>(
                _Item,
                "Trả về thông tin của một loại khách hàng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetPatron,
                    context => PatronKindBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
