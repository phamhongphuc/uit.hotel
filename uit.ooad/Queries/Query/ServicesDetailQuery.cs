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
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<ServicesDetailType>>>>(
                _List,
                "Trả về một danh sách các chi tiết dịch vụ",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetService,
                    context => ServicesDetailBusiness.Get()
                )
            );
            
            Field<NonNullGraphType<ServicesDetailType>>(
                _Item,
                "Trả về thông tin một chi tiết dịch vụ",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetService,
                    context => ServicesDetailBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
