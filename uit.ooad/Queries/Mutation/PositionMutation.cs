using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class PositionMutation : QueryType<Position>
    {
        public PositionMutation()
        {
            Field<PositionType>(
                _Creation,
                "Tạo và trả về một chức vụ mới",
                _InputArgument<PositionCreateInput>(),
                _CheckPermission_Object(
                    p => p.PermissionCreatePosition,
                    context => PositionBusiness.Add(_GetInput(context))
                )
            );
        }
    }
}
