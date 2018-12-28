using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class RoomKindMutation : QueryType<RoomKind>
    {
        public RoomKindMutation()
        {
            Field<NonNullGraphType<RoomKindType>>(
                _Creation,
                "Tạo và trả về một loại phòng",
                _InputArgument<RoomKindCreateInput>(),
                _CheckPermission_Object(
                    p => p.PermissionCreateOrUpdateRoomKind,
                    context => RoomKindBusiness.Add(_GetInput(context))
                )
            );

            Field<NonNullGraphType<RoomKindType>>(
                _Updation,
                "Cập nhật và trả về loại phòng vừa cập nhật",
                _InputArgument<RoomKindUpdateInput>(),
                _CheckPermission_Object(
                    p => p.PermissionCreateOrUpdateRoomKind,
                    context => RoomKindBusiness.Update(_GetInput(context))
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một loại phòng",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionCreateOrUpdateRoomKind,
                    context =>
                    {
                        RoomKindBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
            
            Field<NonNullGraphType<StringGraphType>>(
                _SetIsActive,
                "Cập nhật trạng thái của loại phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission_String(
                    p => p.PermissionCreateOrUpdateRoomKind,
                    context =>
                    {
                        var id = context.GetArgument<int>("id");
                        var isActive = context.GetArgument<bool>("isActive");
                        RoomKindBusiness.SetIsActive(id, isActive);
                        return "Cập nhật trạng thái thành công";
                    }
                )
            );
        }
    }
}
