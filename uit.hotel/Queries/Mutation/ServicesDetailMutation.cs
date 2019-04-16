using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class ServicesDetailMutation : QueryType<ServicesDetail>
    {
        public ServicesDetailMutation()
        {
            Field<NonNullGraphType<ServicesDetailType>>(
                _Creation,
                "Tạo và trả về một chi tiết dịch vụ mới",
                _InputArgument<ServicesDetailCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageHiringRoom,
                    context => ServicesDetailBusiness.Add(_GetInput(context))
                )
            );

            Field<NonNullGraphType<ServicesDetailType>>(
                _Updation,
                "Cập nhật và trả về một chi tiết dịch vụ mới cập nhật",
                _InputArgument<ServicesDetailUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionCleaning,
                    context => ServicesDetailBusiness.Update(_GetInput(context))
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một dịch vụ",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionCleaning,
                    context =>
                    {
                        ServicesDetailBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
        }
    }
}
