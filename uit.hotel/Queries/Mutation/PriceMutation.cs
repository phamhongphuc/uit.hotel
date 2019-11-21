using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class PriceMutation : QueryType<Price>
    {
        public PriceMutation()
        {
            Field<NonNullGraphType<PriceType>>(
                _Creation,
                "Tạo và trả về một loại giá cơ bản mới",
                _InputArgument<PriceCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePrice,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return PriceBusiness.Add(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<PriceType>>(
                _Updation,
                "Cập nhật và trả về một giá cơ bản vừa cập nhật",
                _InputArgument<PriceUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePrice,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return PriceBusiness.Update(employee, _GetInput(context));
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một giá cơ bản",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManagePrice,
                    context =>
                    {
                        PriceBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
        }
    }
}
