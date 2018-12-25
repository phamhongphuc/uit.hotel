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
            Field<RoomType>(
                _Creation,
                "Tạo và trả về một phòng mới",
                _InputArgument<RoomCreateInput>(),
                _CheckPermission(
                    p => p.PermissionUpdateGroundPlan,
                    context => RoomBusiness.Add(_GetInput(context))
                )
            );
            Field<RoomType>(
                _Updation,
                "Cập nhật và trả về một phòng vừa cập nhật",
                _InputArgument<RoomUpdateInput>(),
                _CheckPermission(
                    p => p.PermissionUpdateGroundPlan,
                    context => RoomBusiness.Update(_GetInput(context))
                )
            );
            Field<StringGraphType>(
                _Deletion,
                "Xóa và trả về một phòng vừa xóa",
                _IdArgument(),
                _CheckPermission(
                    p => p.PermissionUpdateGroundPlan,
                    context =>
                    {
                        RoomBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
            Field<StringGraphType>(
                _SetIsActive,
                "Cập nhật trạng thái của một phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission(p => p.PermissionUpdateGroundPlan, context =>
                      {
                          int id = context.GetArgument<int>("id");
                          bool isActive = context.GetArgument<bool>("isActive");
                          RoomBusiness.SetIsActive(id, isActive);
                          return "Cập nhật trạng thái thành công";
                      }
                )
            );
        }
    }
}
