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
            Field<ListGraphType<ServiceType>>(
                _List,
                "Trả về một danh sách các dịch vụ",
                resolve: context => ServiceBusiness.Get()
            );
            Field<ServiceType>(
                _Item,
                "Trả về thông tin một dịch vụ",
                IdArgument(),
                context => ServiceBusiness.Get(GetId<int>(context))
            );
        }
    }
}