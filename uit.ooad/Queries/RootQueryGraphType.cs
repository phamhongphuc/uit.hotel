using GraphQL.Types;

namespace uit.ooad.Queries
{
    public class RootQueryGraphType : ObjectGraphType
    {
        public string GetList<T>()
        {
            return nameof(T) + "s";
        }
        public string GetCreation<T>()
        {
            return "Create" + nameof(T);
        }
        public string GetDeletion<T>()
        {
            return "Delete" + nameof(T);
        }
        public string GetUpdation<T>()
        {
            return "Update" + nameof(T);
        }
    }
}
