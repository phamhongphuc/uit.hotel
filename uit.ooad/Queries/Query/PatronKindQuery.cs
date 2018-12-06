using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Query
{
    public class PatronKindQuery : RootQueryGraphType
    {
        public PatronKindQuery()
        {
            Field<ListGraphType<PatronKindType>>(
                GetList(nameof(PatronKind)),
                "Trả về một danh sách các loại khách hàng có trong hệ thống",
                resolve: context => PatronKindBusiness.Get()
            );
            Field<PatronKindType>(
                nameof(PatronKind),
                "Trả về thông tin của một loại khách hàng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                context => PatronKindBusiness.Get(context.GetArgument<int>("id"))
            );
        }
    }
}
