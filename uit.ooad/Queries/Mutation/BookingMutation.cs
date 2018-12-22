using System.Collections.Generic;
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
            Field<BookingType>(
                _Creation,
                "Tạo và trả về một đơn đặt phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<BookingCreateInput>>>> { Name = "bookings" },
                    new QueryArgument<NonNullGraphType<BillCreateInput>> { Name = "bill" }
                ),
                _CheckPermission(
                    p => p.PermissionCreateBooking,
                    async context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);

                        var bookings = context.GetArgument<List<Booking>>("bookings");
                        var bill = context.GetArgument<Bill>("bill");

                        Bill b = await BillBusiness.Add(employee, bill);

                        // foreach (var booking in bookings)
                        // {
                        //     BookingBusiness.Add(b, booking, employee);
                        // }
                    }
                )
            );

            Field<BookingType>(
                "CheckIn",
                "Cập nhật thời gian checkin của phòng",
                _IdArgument(),
                _CheckPermission(
                    person => person.PermissionCreateBooking,
                    context => BookingBusiness.CheckIn(_GetId<int>(context))
                )
            );
        }
    }
}
