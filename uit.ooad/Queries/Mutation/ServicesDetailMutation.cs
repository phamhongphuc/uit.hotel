using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class ServicesDetailMutation : QueryType<ServicesDetail>
    {
        public ServicesDetailMutation()
        {
            Field<NonNullGraphType<ServicesDetailType>>(
                _Updation,
                "Cập nhật và trả về một chi tiết dịch vụ mới cập nhật",
                _InputArgument<ServicesDetailUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionCleaning,
                    context => ServicesDetailBusiness.Update(_GetInput(context))
                )
            );
        }
    }
}
