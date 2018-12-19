using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class FloorMutation : QueryType<Floor>
    {
        public FloorMutation()
        {
            Field<FloorType>(
                _Creation,
                "Tạo và trả về một tầng mới",
                _InputArgument<FloorCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateFloor,
                    context => FloorBusiness.Add(_GetInput(context))
                )
            );
            Field<FloorType>(
                _Updation,
                "Cập nhật và trả về một tầng vừa cập nhật",
                _InputArgument<FloorUpdateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateFloor,
                    context => FloorBusiness.Update(_GetInput(context))
                )
            );
        }
    }
}
