using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class VolatilityRateMutation : QueryType<VolatilityRate>
    {
        public VolatilityRateMutation()
        {
            Field<NonNullGraphType<VolatilityRateType>>(
                _Creation,
                "Tạo và trả về một giá biến động mới",
                _InputArgument<VolatilityRateCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRate,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return VolatilityRateBusiness.Add(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<VolatilityRateType>>(
                _Updation,
                "Cập nhật và trả về một giá biến động vừa cập nhật",
                _InputArgument<VolatilityRateUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRate,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return VolatilityRateBusiness.Update(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một giá biến động",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManageRate,
                    context =>
                    {
                        VolatilityRateBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
        }
    }
}
