using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class ServiceQuery : QueryType<Service>
    {
        public ServiceQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<ServiceType>>>>(
                _List,
                "Trả về một danh sách các dịch vụ",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetService,
                    context => ServiceBusiness.Get()
                )
            );
            
            Field<NonNullGraphType<ServiceType>>(
                _Item,
                "Trả về thông tin một dịch vụ",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetService,
                    context => ServiceBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
