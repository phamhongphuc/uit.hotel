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
                InputArgument<BookingCreateInput>(),
                context => BookingBusiness.Add(GetInput(context))
            );
        }
    }
}