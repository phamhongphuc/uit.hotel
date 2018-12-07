using uit.ooad.Queries.Base;
using uit.ooad.Queries.Query;

namespace uit.ooad.Queries
{
    public class AppQuery : AppType
    {
        public AppQuery()
        {
            AddFields(
                new RoomQuery(),
                new RoomKindQuery(),
                new FloorQuery(),
                new EmployeeeQuery(),
                new PatronQuery(),
                new PatronKindQuery(),
                new HouseKeepingQuery()
            );
        }
    }
}
