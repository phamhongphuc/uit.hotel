using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Query
{
    public class PatronQuery : RootQueryGraphType
    {
        public PatronQuery()
        {
            Field<ListGraphType<PatronType>>(
                GetList(nameof(Patron)),
                "Trả về một danh sách các khách hàng",
                resolve: context => PatronBusiness.Get()
            );
            Field<PatronType>(
                nameof(Patron),
                "Trả về thông tin một khách hàng",
                new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                context => PatronBusiness.Get(context.GetArgument<int>("id"))
            );
        }
    }
}
