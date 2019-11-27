using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class PriceVolatilityQuery : QueryType<PriceVolatility>
    {
        public PriceVolatilityQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PriceVolatilityType>>>>(
                "PriceVolatilities",
                "Trả về một danh sách các giá biến động",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetPrice,
                    context => PriceVolatilityBusiness.Get()
                )
            );

            Field<NonNullGraphType<PriceVolatilityType>>(
                _Item,
                "Trả về thông tin một giá biến động",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetPrice,
                    context => PriceVolatilityBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
