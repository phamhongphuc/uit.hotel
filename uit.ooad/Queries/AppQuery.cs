using uit.ooad.Queries.Base;
using uit.ooad.Queries.Query;

namespace uit.ooad.Queries
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
                new BookingQuery()
            );
        }
    }
}
