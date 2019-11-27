using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class BookingMutation : QueryType<Booking>
    {
        public BookingMutation()
        {
            Field<NonNullGraphType<BookingType>>(
                "CheckIn",
                "Nhận phòng",
                _IdArgument(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRentingRoom,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return BookingBusiness.CheckIn(employee, _GetId<int>(context));
                    }
                )
            );

            Field<NonNullGraphType<BookingType>>(
                "CheckOut",
                "Trả phòng",
                _IdArgument(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRentingRoom,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return BookingBusiness.CheckOut(employee, _GetId<int>(context));
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                "Cancel",
                "Hủy đặt phòng",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManageRentingRoom,
                    context =>
                    {
                        BookingBusiness.Cancel(_GetId<int>(context));
                        return "Hủy thành công";
                    }
                )
            );

            Field<NonNullGraphType<BookingType>>(
                "AddBookingToBill",
                "Thêm phòng vào hóa đơn",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<BillIdInput>> { Name = "bill" },
                    new QueryArgument<NonNullGraphType<BookingCreateInput>> { Name = "booking" }
                ),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageRentingRoom,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        var bill = context.GetArgument<Bill>("bill");
                        var booking = context.GetArgument<Booking>("booking");

                        return BookingBusiness.Add(employee, bill, booking);
                    }
                )
            );

            Field<NonNullGraphType<BookingType>>(
                "CheckBookingPrice",
                "Kiểm tra thử giá của phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookingCreateInput>> { Name = "booking" }
                ),
                _CheckPermission_Object(
                    p => p.PermissionManageRentingRoom,
                    context =>
                    {
                        var booking = context.GetArgument<Booking>("booking");
                        booking.CalculatePrice();
                        return booking;
                    }
                )
            );
        }
    }
}
