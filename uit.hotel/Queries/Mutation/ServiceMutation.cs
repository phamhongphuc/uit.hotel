using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class ServiceMutation : QueryType<Service>
    {
        public ServiceMutation()
        {
            Field<NonNullGraphType<ServiceType>>(
                _Creation,
                "Tạo và trả về một dịch vụ mới",
                _InputArgument<ServiceCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageService,
                    context => ServiceBusiness.Add(_GetInput(context))
                )
            );

            Field<NonNullGraphType<ServiceType>>(
                _Updation,
                "Cập nhật và trả về một dịch vụ mới cập nhật",
                _InputArgument<ServiceUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageService,
                    context => ServiceBusiness.Update(_GetInput(context))
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một dịch vụ",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManageService,
                    context =>
                    {
                        ServiceBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                "SetIsActiveService",
                "Cập nhật trạng thái của dịch vụ",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission_String(
                    p => p.PermissionManageService,
                    context =>
                    {
                        var serviceId = context.GetArgument<int>("id");
                        var isActive = context.GetArgument<bool>("isActive");

                        ServiceBusiness.SetIsActive(serviceId, isActive);
                        return "Thành công";
                    }
                )
            );
        }
    }
}
