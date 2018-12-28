using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class ReceiptMutation : QueryType<Receipt>
    {
        public ReceiptMutation()
        {
            Field<NonNullGraphType<ReceiptType>>(
                _Creation,
                "Tạo và trả về một phiếu thu mới",
                _InputArgument<ReceiptCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionCreateReceipt,
                    context => ReceiptBusiness.Add(_GetInput(context))
                )
            );
        }
    }
}
