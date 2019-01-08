using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class RateQuery : QueryType<Rate>
    {
        public RateQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<RateType>>>>(
                _List,
                "Trả về một danh sách các loại giá cơ bản",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetRate,
                    context => RateBusiness.Get()
                )
            );

            Field<NonNullGraphType<RateType>>(
                _Item,
                "Trả về thông tin một loại giá cơ bản",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetRate,
                    context => RateBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
