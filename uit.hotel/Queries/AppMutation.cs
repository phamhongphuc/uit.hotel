using uit.hotel.Queries.Base;
using uit.hotel.Queries.Mutation;

namespace uit.hotel.Queries
{
    public class AppMutation : AppType
    {
        public AppMutation()
        {
            AddFields(
                new AuthenticationMutation(),
                new BillMutation(),
                new BookingMutation(),
                new EmployeeMutation(),
                new FloorMutation(),
                new InitializeMutation(),
                new PatronKindMutation(),
                new PatronMutation(),
                new PositionMutation(),
                new PriceMutation(),
                new PriceVolatilityMutation(),
                new ReceiptMutation(),
                new RoomKindMutation(),
                new RoomMutation(),
                new ServiceMutation(),
                new ServicesDetailMutation()
            );
        }
    }
}
