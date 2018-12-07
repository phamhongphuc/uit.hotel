using System.Security.Claims;
using uit.ooad.Businesses;
using uit.ooad.GraphQL;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class ReceiptMutation : QueryType<Receipt>
    {
        public ReceiptMutation()
        {
            Field<ReceiptType>(
                _Creation,
                "Tạo và trả về một phiếu thu mới",
                InputArgument<ReceiptCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateReceipt,
                    context => ReceiptBusiness.Add(GetInput(context))
                )
            );
        }
    }
}
