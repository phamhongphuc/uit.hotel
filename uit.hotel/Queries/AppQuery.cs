using uit.hotel.Queries.Base;
using uit.hotel.Queries.Query;

namespace uit.hotel.Queries
{
    public class AppQuery : AppType
    {
        public AppQuery()
        {
            AddFields(
                new BillQuery(),
                new BookingQuery(),
                new EmployeeQuery(),
                new FloorQuery(),
                new InitializeQuery(),
                new PatronKindQuery(),
                new PatronQuery(),
                new PositionQuery(),
                new PriceQuery(),
                new ReceiptQuery(),
                new RoomKindQuery(),
                new RoomQuery(),
                new ServiceQuery(),
                new ServicesDetailQuery(),
                new VolatilityPriceQuery()
            );
        }
    }
}
