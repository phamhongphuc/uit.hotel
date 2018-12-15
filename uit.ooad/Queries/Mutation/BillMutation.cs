using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class BillMutation : QueryType<Bill>
    {
        public BillMutation()
        {
            Field<BillType>(
                _Creation,
                "Tạo và trả về một hóa đơn mới",
                _InputArgument<BillCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateBill,
                    context => {
                        // var employee = AuthenticationHelper.GetEmployee(context);
                        return BillBusiness.Add(_GetInput(context));
                    }
                )
            );
        }
    }
}
