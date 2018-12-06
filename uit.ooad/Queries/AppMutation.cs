using uit.ooad.Queries.Mutation;

namespace uit.ooad.Queries
{
    public class AppMutation : RootObjectGraphType
    {
        public AppMutation()
        {
            AddFields(
                new RoomMutation(),
                new FloorMutation(),
                new EmployeeeMutation()
            );
        }
    }
}
