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
                new EmployeeQuery(),
                new FloorQuery(),
                new HouseKeepingQuery(),
                new PatronQuery(),
                new PatronKindQuery(),
                new ServiceQuery(),
                new ServicesDetailQuery(),
                new PositionQuery(),
                new RateQuery(),
                new ReceiptQuery(),
                new RoomKindQuery(),
                new RoomQuery(),
                new BookingQuery(),
                new VolatilityRateQuery()
            );
        }
    }
}
