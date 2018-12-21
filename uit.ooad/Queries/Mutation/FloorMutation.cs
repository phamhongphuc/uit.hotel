using GraphQL.Types;
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
                    p => p.PermissionCreateOrUpdateFloor,
                    context => FloorBusiness.Add(_GetInput(context))
                )
            );
            Field<FloorType>(
                _Updation,
                "Cập nhật và trả về một tầng vừa cập nhật",
                _InputArgument<FloorUpdateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateOrUpdateFloor,
                    context => FloorBusiness.Update(_GetInput(context))
                )
            );
            Field<FloorType>(
                _Deletion,
                "Xóa một tầng",
                _IdArgument(),
                _CheckPermission<string>(
                    p => p.PermissionCreateOrUpdateFloor,
                    context =>
                    {
                        FloorBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
            Field<FloorType>(
                _SetIsActive,
                "Cập nhật trạng thái của tầng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission(
                    p => p.PermissionCreateOrUpdateFloor,
                    context =>
                    {
                        var id = context.GetArgument<int>("id");
                        var isActive = context.GetArgument<bool>("isActive");
                        FloorBusiness.SetIsActive(id, isActive);
                        return "Cập nhật trạng thái thành công";
                    }
                )
            );
        }
    }
}
