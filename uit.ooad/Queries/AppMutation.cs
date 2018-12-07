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

                new EmployeeeMutation(),
                new FloorMutation(),
                new PatronKindMutation(),
                new PatronMutation(),
                new PatronKindMutation(),
                new RateMutation(),
                new RoomKindMutation(),
                new RoomMutation()
            );
        }
    }
}
