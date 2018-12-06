using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Interface;

namespace uit.ooad.Queries.Query
{
    public class PatronQuery : RootQueryGraphType<Patron>
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
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                context => PatronBusiness.Get(context.GetArgument<int>("id"))
            );
        }
    }
}
