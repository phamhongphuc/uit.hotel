using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class BookingMutation : QueryType<Booking>
    {
        public BookingMutation()
        {
            Field<NonNullGraphType<BookingType>>(
                "CheckIn",
                "Cập nhật thời gian checkin của phòng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionManageHiringRooms,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return BookingBusiness.CheckIn(employee, _GetId<int>(context));
                    }
                )
            );

            Field<NonNullGraphType<BookingType>>(
                "RequestCheckOut",
                "Yêu cầu kiểm tra khi trả phòng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionManageHiringRooms,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return BookingBusiness.RequestCheckOut(employee, _GetId<int>(context));
                    }
                )
            );

            Field<NonNullGraphType<BookingType>>(
                "CheckOut",
                "Thực hiện xác nhận trả phòng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionManageHiringRooms,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return BookingBusiness.CheckOut(employee, _GetId<int>(context));
                    }
                )
            );
            
            Field<NonNullGraphType<BookingType>>(
                "AddBookingToBill",
                "Thêm phòng khách đoàn",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "billId" },
                    new QueryArgument<NonNullGraphType<BookingCreateInput>> { Name = "booking" }
                ),
                _CheckPermission_Object(
                    p => p.PermissionManageHiringRooms,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        var billId = context.GetArgument<int>("billId");
                        var booking = context.GetArgument<Booking>("booking");

                        return BookingBusiness.Add(employee, billId, booking);
                    }
                )
            );
        }
    }
}
