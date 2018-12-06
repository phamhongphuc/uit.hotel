using GraphQL.Types;

namespace uit.ooad.Queries.Interface
{
    public class RootQueryGraphType<T> : ObjectGraphType
    {
        public string _Item
        {
            get => typeof(T).Name;
        }

        public string _List
        {
            get => typeof(T).Name + "s";
        }

        public string _Creation
        {
            get => "Create" + typeof(T).Name;
        }

        public string _Deletion
        {
            get => "Delete" + typeof(T).Name;
        }

        public string _Updation
        {
            get => "Update" + typeof(T).Name;
        }
    }
}
