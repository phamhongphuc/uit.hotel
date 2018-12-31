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
            Field<NonNullGraphType<FloorType>>(
                _Creation,
                "Tạo và trả về một tầng mới",
                _InputArgument<FloorCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionUpdateGroundPlan,
                    context => FloorBusiness.Add(_GetInput(context))
                )
            );

            Field<NonNullGraphType<FloorType>>(
                _Updation,
                "Cập nhật và trả về một tầng vừa cập nhật",
                _InputArgument<FloorUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionUpdateGroundPlan,
                    context => FloorBusiness.Update(_GetInput(context))
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một tầng",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionUpdateGroundPlan,
                    context =>
                    {
                        FloorBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _SetIsActive,
                "Cập nhật trạng thái hoạt động của tầng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission_String(
                    p => p.PermissionUpdateGroundPlan,
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
