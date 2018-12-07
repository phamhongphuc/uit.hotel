using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class PatronQuery : QueryType<Patron>
    {
        public PatronQuery()
        {
            Field<ListGraphType<PatronType>>(
                _List,
                "Trả về một danh sách các khách hàng",
                resolve: context => PatronBusiness.Get()
            );
            Field<PatronType>(
                _Item,
                "Trả về thông tin một khách hàng",
                IdArgument(),
                context => PatronBusiness.Get(GetId<string>(context))
            );
        }
    }
}
