using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class FloorQuery : QueryType<Floor>
    {
        public FloorQuery()
        {
            Field<FloorType>(
                _Item,
                "Trả về thông tin một tầng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                context => FloorBusiness.Get(context.GetArgument<int>("id"))
            );
            Field<ListGraphType<FloorType>>(
                _List,
                "Trả về một danh sách các tầng",
                resolve: context => FloorBusiness.Get()
            );
        }
    }
}
