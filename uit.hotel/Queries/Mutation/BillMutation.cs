using System.Collections.Generic;
using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class BillMutation : QueryType<Bill>
    {
        public BillMutation()
        {
            Field<NonNullGraphType<BillType>>(
                _Creation,
                "Tạo và trả về một đơn đặt phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<BookingCreateInput>>>>
                    { Name = "bookings" },
                    new QueryArgument<NonNullGraphType<BillCreateInput>> { Name = "bill" }
                ),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageHiringRoom,
                    async context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        var bill = context.GetArgument<Bill>("bill");
                        var bookings = context.GetArgument<List<Booking>>("bookings");

                        var billInDatabase = await BillBusiness.Book(employee, bill, bookings);
                        return billInDatabase;
                    }
                )
            );

            Field<NonNullGraphType<BillType>>(
                "BookAndCheckIn",
                "Đặt và nhận phòng ngay tại khách sạn",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<BookAndCheckInCreateInput>>>>
                    { Name = "bookings" },
                    new QueryArgument<NonNullGraphType<BillCreateInput>> { Name = "bill" }
                ),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageHiringRoom,
                    async context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        var bill = context.GetArgument<Bill>("bill");
                        var bookings = context.GetArgument<List<Booking>>("bookings");

                        return await BillBusiness.BookAndCheckIn(employee, bill, bookings);
                    }
                )
            );

            Field<NonNullGraphType<BillType>>(
                "PayTheBill",
                "Thanh toán hóa đơn (thanh toán tiền phòng)",
                _IdArgument(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageHiringRoom,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return BillBusiness.PayTheBill(employee, _GetId<int>(context));
                    }
                )
            );
        }
    }
}
