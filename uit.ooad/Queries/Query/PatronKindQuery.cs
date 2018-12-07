using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class PatronKindQuery : QueryType<PatronKind>
    {
        public PatronKindQuery()
        {
            Field<ListGraphType<PatronKindType>>(
                _List,
                "Trả về một danh sách các loại khách hàng có trong hệ thống",
                resolve: context => PatronKindBusiness.Get()
            );
            Field<PatronKindType>(
                _Item,
                "Trả về thông tin của một loại khách hàng",
                IdArgument(),
                context => PatronKindBusiness.Get(GetId<int>(context))
            );
        }
    }
}
