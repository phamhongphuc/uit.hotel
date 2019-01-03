using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class RoomMutation : QueryType<Room>
    {
        public RoomMutation()
        {
            Field<NonNullGraphType<RoomType>>(
                _Creation,
                "Tạo và trả về một phòng mới",
                _InputArgument<RoomCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageMap,
                    context => RoomBusiness.Add(_GetInput(context))
                )
            );

            Field<NonNullGraphType<RoomType>>(
                _Updation,
                "Cập nhật và trả về một phòng vừa cập nhật",
                _InputArgument<RoomUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageMap,
                    context => RoomBusiness.Update(_GetInput(context))
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một phòng",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManageMap,
                    context =>
                    {
                        RoomBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _SetIsActive,
                "Cập nhật trạng thái hoạt động của một phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission_String(
                    p => p.PermissionManageMap,
                    context =>
                    {
                        var id = context.GetArgument<int>("id");
                        var isActive = context.GetArgument<bool>("isActive");
                        RoomBusiness.SetIsActive(id, isActive);
                        return "Cập nhật trạng thái thành công";
                    }
                )
            );
        }
    }
}
