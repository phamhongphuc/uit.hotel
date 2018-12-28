using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class PositionQuery : QueryType<Position>
    {
        public PositionQuery()
        {
            Field<ListGraphType<PositionType>>(
                _List,
                "Trả về một danh sách các chức vụ",
                resolve: context => PositionBusiness.Get()
            );
            Field<PositionType>(
                _Item,
                "Trả về thông tin một chức vụ",
                _IdArgument(),
                context => PositionBusiness.Get(_GetId<int>(context))
            );
        }
    }
}
