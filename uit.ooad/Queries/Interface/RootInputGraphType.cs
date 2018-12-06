using GraphQL.Types;

namespace uit.ooad.Queries.Interface
{
    public class RootInputGraphType<T> : InputObjectGraphType<T>
    {
        public string _Creation
        {
            get => "Create" + typeof(T).Name + "Input";
        }

        public string _Updation
        {
            get => "Update" + typeof(T).Name + "Input";
        }
    }
}
