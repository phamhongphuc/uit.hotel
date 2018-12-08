using uit.ooad.Queries.Base;
using uit.ooad.Queries.Mutation;

namespace uit.ooad.Queries
{
    public class AppMutation : AppType
    {
        public AppMutation()
        {
            AddFields(
                new AuthenticationMutation(),
                new BillMutation(),
                new EmployeeMutation(),
                new FloorMutation(),
                new HouseKeepingMutation(),
                new PatronKindMutation(),
                new PatronMutation(),
                new PositionMutation(),
                new RateMutation(),
                new ReceiptMutation(),
                new RoomKindMutation(),
                new RoomMutation(),
                new ServiceMutation(),
                new ServicesDetailMutation(),
                new BookingMutation(),
                new VolatilityRateMutation()
            );
        }
    }
}
