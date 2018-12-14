using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class ServiceMutation : QueryType<Service>
    {
        public ServiceMutation()
        {
            Field<ServiceType>(
                _Creation,
                "Tạo và trả về một dịch vụ mới",
                _InputArgument<ServiceCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateService,
                    context => ServiceBusiness.Add(_GetInput(context))
                )
            );
        }
    }
}
