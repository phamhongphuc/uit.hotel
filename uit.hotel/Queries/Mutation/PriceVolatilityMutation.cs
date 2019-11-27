using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class PriceVolatilityMutation : QueryType<PriceVolatility>
    {
        public PriceVolatilityMutation()
        {
            Field<NonNullGraphType<PriceVolatilityType>>(
                _Creation,
                "Tạo và trả về một giá biến động mới",
                _InputArgument<PriceVolatilityCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePrice,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return PriceVolatilityBusiness.Add(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<PriceVolatilityType>>(
                _Updation,
                "Cập nhật và trả về một giá biến động vừa cập nhật",
                _InputArgument<PriceVolatilityUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePrice,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return PriceVolatilityBusiness.Update(employee, _GetInput(context));
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
                        PriceVolatilityBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
        }
    }
}
