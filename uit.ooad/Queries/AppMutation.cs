using uit.ooad.Queries.Base;
using uit.ooad.Queries.Mutation;

namespace uit.ooad.Queries
{
    public class AppMutation : AppType
    {
        public AppMutation()
        {
            AddFields(
                new FloorMutation(),
                new EmployeeeMutation(),
                new PatronMutation(),
                new PatronKindMutation()
            );
        }
    }
}
