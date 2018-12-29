using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class ReceiptQuery : QueryType<Receipt>
    {
        public ReceiptQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<ReceiptType>>>>(
                _List,
                "Trả về một danh sách các phiếu thu",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetVoucher,
                    context => ReceiptBusiness.Get()
                )
            );

            Field<NonNullGraphType<ReceiptType>>(
                _Item,
                "Trả về thông tin một phiếu thu",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetVoucher,
                    context => ReceiptBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
