using uit.ooad.Queries.Mutation;

namespace uit.ooad.Queries
{
    public class AppMutation : RootObjectGraphType
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
