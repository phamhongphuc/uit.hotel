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
                new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "identification" }),
                context => PatronBusiness.Get(context.GetArgument<string>("identification"))
            );

            Field<ListGraphType<PatronType>>(
                _Finding,
                "Trả về danh sách khách hàng theo từ khóa tìm kiếm",
                new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                context =>
                {
                    var id = context.GetArgument<string>("id");
                    return PatronBusiness.Query(id);
                }
            );
        }
    }
}
