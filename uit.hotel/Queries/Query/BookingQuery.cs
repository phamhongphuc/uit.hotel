using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class BookingQuery : QueryType<Booking>
    {
        public BookingQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BookingType>>>>(
                _List,
                "Trả về một danh sách các đơn đặt phòng",
                resolve: _CheckPermission_List(
                    p => p.PermissionManageRentingRoom,
                    context => BookingBusiness.Get()
                )
            );

            Field<NonNullGraphType<BookingType>>(
                _Item,
                "Trả về thông tin một đơn đặt phòng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionManageRentingRoom,
                    context => BookingBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
