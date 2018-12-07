using Microsoft.Extensions.Configuration;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;
using uit.ooad.Queries.Mutation;

namespace uit.ooad.Queries
{
    public class AppMutation : AppType
    {
        public AppMutation(AuthenticationHelper authentication)
        {
            AddFields(
                new AuthenticationMutation(authentication),
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
                new HouseKeepingMutation(),
                new ServiceMutation(),
                new ServicesDetailMutation()
            );
        }
    }
}
