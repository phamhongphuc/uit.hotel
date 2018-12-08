using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class ServicesDetailQuery : QueryType<ServicesDetail>
    {
        public ServicesDetailQuery()
        {
            Field<ListGraphType<ServicesDetailType>>(
                _List,
                "Trả về một danh sách các chi tiết dịch vụ",
                resolve: context => ServicesDetailBusiness.Get()
            );
            Field<ServicesDetailType>(
                _Item,
                "Trả về thông tin một chi tiết dịch vụ",
                IdArgument(),
                context => ServicesDetailBusiness.Get(GetId<int>(context))
            );
        }
    }
}
