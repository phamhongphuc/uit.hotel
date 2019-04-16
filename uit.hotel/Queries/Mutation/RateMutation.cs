using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class RateMutation : QueryType<Rate>
    {
        public RateMutation()
        {
            Field<NonNullGraphType<RateType>>(
                _Creation,
                "Tạo và trả về một loại giá cơ bản mới",
                _InputArgument<RateCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRate,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return RateBusiness.Add(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<RateType>>(
                _Updation,
                "Cập nhật và trả về một giá cơ bản vừa cập nhật",
                _InputArgument<RateUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRate,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return RateBusiness.Update(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một giá cơ bản",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManageRate,
                    context =>
                    {
                        RateBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
        }
    }
}
