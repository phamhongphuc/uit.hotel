using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class ReceiptQuery : QueryType<Receipt>
    {
        public ReceiptQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<ReceiptType>>>>(
                _List,
                "Trả về một danh sách các phiếu thu",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetAccountingVoucher,
                    context => ReceiptBusiness.Get()
                )
            );

            Field<NonNullGraphType<ReceiptType>>(
                _Item,
                "Trả về thông tin một phiếu thu",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetAccountingVoucher,
                    context => ReceiptBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
