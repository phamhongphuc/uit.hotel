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
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BookingType>>>>(
                _List,
                "Trả về một danh sách các đơn đặt phòng",
                resolve: _CheckPermission_List(
                    p => p.PermissionManageHiringRoom,
                    context => BookingBusiness.Get()
                )
            );

            Field<NonNullGraphType<BookingType>>(
                _Item,
                "Trả về thông tin một đơn đặt phòng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionManageHiringRoom,
                    context => BookingBusiness.Get(_GetId<int>(context))
                )
            );
        }
    }
}
