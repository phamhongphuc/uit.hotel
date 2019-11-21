using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class VolatilityPriceMutation : QueryType<VolatilityPrice>
    {
        public VolatilityPriceMutation()
        {
            Field<NonNullGraphType<VolatilityPriceType>>(
                _Creation,
                "Tạo và trả về một giá biến động mới",
                _InputArgument<VolatilityPriceCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePrice,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return VolatilityPriceBusiness.Add(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<VolatilityPriceType>>(
                _Updation,
                "Cập nhật và trả về một giá biến động vừa cập nhật",
                _InputArgument<VolatilityPriceUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePrice,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return VolatilityPriceBusiness.Update(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một giá biến động",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManagePrice,
                    context =>
                    {
                        VolatilityPriceBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
        }
    }
}
