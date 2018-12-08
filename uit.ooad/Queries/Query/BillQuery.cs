using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class BillQuery : QueryType<Bill>
    {
        public BillQuery()
        {
            Field<ListGraphType<BillType>>(
                _List,
                "Trả về một danh sách các hóa đơn",
                resolve: context => BillBusiness.Get()
            );
            Field<BillType>(
                _Item,
                "Trả về thông tin một hóa đơn",
                IdArgument(),
                context => BillBusiness.Get(GetId<string>(context))
            );
        }
    }
}
