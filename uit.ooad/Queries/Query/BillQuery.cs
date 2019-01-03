using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class BillQuery : QueryType<Bill>
    {
        public BillQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BillType>>>>(
                _List,
                "Trả về một danh sách các hóa đơn",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetAccountingVoucher,
                    context => BillBusiness.Get()
                )
            );

            Field<NonNullGraphType<BillType>>(
                _Item,
                "Trả về thông tin một hóa đơn",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetAccountingVoucher,
                    context => BillBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
