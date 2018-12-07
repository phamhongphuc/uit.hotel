using Microsoft.Extensions.Configuration;
using uit.ooad.Queries.Base;
using uit.ooad.Queries.Mutation;

namespace uit.ooad.Queries
{
    public class AppMutation : AppType
    {
        public AppMutation(IConfiguration configuration)
        {
            AddFields(
                new AuthenticationMutation(configuration),

                new EmployeeeMutation(),
                new FloorMutation(),
                new PatronKindMutation(),
                new PatronMutation(),
                new RoomKindMutation(),
                new RoomMutation()
            );
        }
    }
}
