using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class ReceiptMutation : QueryType<Receipt>
    {
        public ReceiptMutation()
        {
            Field<NonNullGraphType<ReceiptType>>(
                _Creation,
                "Tạo và trả về một phiếu thu tiền mặt mới",
                _InputArgument<ReceiptCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRentingRoom,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return ReceiptBusiness.AddCash(employee, _GetInput(context));
                    }
                )
            );
        }
    }
}
