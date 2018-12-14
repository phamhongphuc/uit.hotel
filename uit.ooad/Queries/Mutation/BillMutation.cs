using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
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
                    context => BillBusiness.Add(_GetInput(context))
                )
            );
        }
    }
}
