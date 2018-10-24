using System.Security.Claims;
using GraphQL.Authorization;

namespace uit.ooad.GraphQL
{
    /**
     * Class này được sinh ra để làm trung gian truyền vào trong Controller
     * Ngoài ra nó không còn bất kì mục đích rõ ràng nào 
     */
    public class GraphQLUserContext : IProvideClaimsPrincipal
    {
        public ClaimsPrincipal User { get; set; }
    }
}
