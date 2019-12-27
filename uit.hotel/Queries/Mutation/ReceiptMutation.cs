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
                "Tạo và trả về một phiếu thu tiền mới",
                _InputArgument<ReceiptCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRentingRoom,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return ReceiptBusiness.Add(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<ReceiptType>>(
                "Check" + nameof(Receipt),
                "Kiểm tra trạng thái của một phiếu thu",
                _IdArgument(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRentingRoom,
                    context => ReceiptBusiness.Check(_GetId<int>(context))
                )
            );
        }
    }
}
