using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class VolatilityRateQuery : QueryType<VolatilityRate>
    {
        public VolatilityRateQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<VolatilityRateType>>>>(
                _List,
                "Trả về một danh sách các giá biến động",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetRate,
                    context => VolatilityRateBusiness.Get()
                )
            );
            
            Field<NonNullGraphType<VolatilityRateType>>(
                _Item,
                "Trả về thông tin một giá biến động",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetRate,
                    context => VolatilityRateBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
