using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class VolatilityPriceQuery : QueryType<VolatilityPrice>
    {
        public VolatilityPriceQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<VolatilityPriceType>>>>(
                _List,
                "Trả về một danh sách các giá biến động",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetPrice,
                    context => VolatilityPriceBusiness.Get()
                )
            );

            Field<NonNullGraphType<VolatilityPriceType>>(
                _Item,
                "Trả về thông tin một giá biến động",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetPrice,
                    context => VolatilityPriceBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
