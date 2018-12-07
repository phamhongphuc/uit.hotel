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
                new PatronKindQuery(),
                new PatronQuery(),
                new RateQuery(),
                new RoomKindQuery(),
                new RoomQuery()
            );
        }
    }
}
