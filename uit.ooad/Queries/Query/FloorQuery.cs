using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Query
{
    public class FloorQuery : RootQueryGraphType
    {
        public FloorQuery()
        {
            Field<ListGraphType<FloorType>>(
                GetCreation<Floor>(),
                "Trả về một danh sách các tầng",
                resolve: context => FloorBusiness.Get()
            );
            Field<FloorType>(
                nameof(Floor),
                "Trả về thông tin một tầng",
                new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                context => FloorBusiness.Get(context.GetArgument<int>("id"))
            );
        }
    }
}
