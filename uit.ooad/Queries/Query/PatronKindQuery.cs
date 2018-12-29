using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class PatronKindQuery : QueryType<PatronKind>
    {
        public PatronKindQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PatronKindType>>>>(
                _List,
                "Trả về một danh sách các loại khách hàng có trong hệ thống",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetPatronKind,
                    context => PatronKindBusiness.Get()
                )
            );
            
            Field<NonNullGraphType<PatronKindType>>(
                _Item,
                "Trả về thông tin của một loại khách hàng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetPatronKind,
                    context => PatronKindBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
