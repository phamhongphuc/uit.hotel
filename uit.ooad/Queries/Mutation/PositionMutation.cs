using GraphQL.Types;
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
            Field<NonNullGraphType<PositionType>>(
                _Creation,
                "Tạo và trả về một chức vụ mới",
                _InputArgument<PositionCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePosition,
                    context => PositionBusiness.Add(_GetInput(context))
                )
            );
            
            Field<NonNullGraphType<PositionType>>(
                _Updation,
                "Cập nhật và trả về một chức vụ vừa cập nhật",
                _InputArgument<PositionUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePosition,
                    context => PositionBusiness.Update(_GetInput(context))
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một chức vụ",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManagePosition,
                    context =>
                    {
                        PositionBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _SetIsActive,
                "Cập nhật trạng thái hoạt động của chức vụ",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission_String(
                    p => p.PermissionManagePosition,
                    context =>
                    {
                        var id = context.GetArgument<int>("id");
                        var isActive = context.GetArgument<bool>("isActive");
                        PositionBusiness.SetIsActive(id, isActive);
                        return "Cập nhật trạng thái thành công";
                    }
                )
            );

            //đặt tên : setIsActivePosition
            // setIsActivePositionAndMoveEmployee
        }
    }
}
