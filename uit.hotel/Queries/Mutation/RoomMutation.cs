using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
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

            Field<NonNullGraphType<StringGraphType>>(
                "SetIsClean",
                "Cập nhật trạng thái dọn phòng của một phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isClean" }
                ),
                _CheckPermission_String(
                    p => p.PermissionCleaning,
                    context =>
                    {
                        var id = context.GetArgument<int>("id");
                        var isClean = context.GetArgument<bool>("isClean");
                        RoomBusiness.SetIsClean(id, isClean);
                        return "Cập nhật trạng thái dọn phòng thành công";
                    }
                )
            );
        }
    }
}
