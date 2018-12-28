using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class BookingQuery : QueryType<Booking>
    {
        public BookingQuery()
        {
            Field<ListGraphType<BookingType>>(
                _List,
                "Trả về một danh sách các đơn đặt phòng",
                resolve: context => BookingBusiness.Get()
            );
            Field<BookingType>(
                _Item,
                "Trả về thông tin một đơn đặt phòng",
                _IdArgument(),
                context => BookingBusiness.Get(_GetId<int>(context))
            );
        }
    }
}
