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
            Field<ListGraphType<VolatilityRateType>>(
                _List,
                "Trả về một danh sách các giá biến động",
                resolve: context => VolatilityRateBusiness.Get()
            );
            Field<VolatilityRateType>(
                _Item,
                "Trả về thông tin một giá biến động",
                _IdArgument(),
                context => VolatilityRateBusiness.Get(_GetId<int>(context))
            );
        }
    }
}
