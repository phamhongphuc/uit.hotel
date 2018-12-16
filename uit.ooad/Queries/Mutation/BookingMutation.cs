using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
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
                _InputArgument<BookingCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateBooking,
                    context => BookingBusiness.Add(_GetInput(context))
                )
            );

            Field<BookingType>(
                "CheckIn",
                "Cập nhật thời gian checkin của phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                ),
                _CheckPermission(
                    person => person.PermissionCreateBooking,
                    context => BookingBusiness.CheckIn(_GetId<int>(context))
                )
            );
        }
    }
}
