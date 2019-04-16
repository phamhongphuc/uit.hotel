using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
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

            Field<NonNullGraphType<StringGraphType>>(
                "SetIsActivePositionAndMoveEmployee",
                "Vô hiệu hóa chức vụ và chuyển nhân viên sang chức vụ mới",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "newId" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission_String(
                    p => p.PermissionManagePosition,
                    context =>
                    {
                        var id = context.GetArgument<int>("id");
                        var newId = context.GetArgument<int>("newId");
                        var isActive = context.GetArgument<bool>("isActive");
                        PositionBusiness.SetIsActiveAndMoveEmployee(id, newId, isActive);
                        return "Cập nhật trạng thái và chuyển nhân viên thành công";
                    }
                )
            );
        }
    }
}
