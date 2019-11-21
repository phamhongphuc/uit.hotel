using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class PriceQuery : QueryType<Price>
    {
        public PriceQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PriceType>>>>(
                _List,
                "Trả về một danh sách các loại giá cơ bản",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetPrice,
                    context => PriceBusiness.Get()
                )
            );

            Field<NonNullGraphType<PriceType>>(
                _Item,
                "Trả về thông tin một loại giá cơ bản",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetPrice,
                    context => PriceBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
