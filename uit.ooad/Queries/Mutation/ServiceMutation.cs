using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class ServiceMutation : QueryType<Service>
    {
        public ServiceMutation()
        {
            Field<ServiceType>(
                _Creation,
                "Tạo và trả về một dịch vụ mới",
                _InputArgument<ServiceCreateOrUpdateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateOrUpdateService,
                    context => ServiceBusiness.Add(_GetInput(context))
                )
            );
            Field<ServiceType>(
                 _Updation,
                 "Cập nhật và trả về một dịch vụ mới cập nhật",
                 _InputArgument<ServiceCreateOrUpdateInput>(),
                 _CheckPermission(
                     p => p.PermissionCreateOrUpdateService,
                     context => ServiceBusiness.Update(_GetInput(context))
                 )
             );
            Field<ServiceType>(
                "SetIsActiveService",
                "Cập nhật trạng thái của dịch vụ",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                context => ServiceBusiness.SetIsActive(
                    context.GetArgument<int>("id"),
                    context.GetArgument<bool>("isActive")
                )
            );
        }
    }
}
