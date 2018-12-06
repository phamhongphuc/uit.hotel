using GraphQL.Types;

namespace uit.ooad.Queries.Base
{
    public class InputType<T> : InputObjectGraphType<T>
    {
        public string _Creation
        {
            get => "Create" + typeof(T).Name + "Input";
        }

        public string _Updation
        {
            get => "Update" + typeof(T).Name + "Input";
        }

        public string _Id<TGraphType>() => typeof(TGraphType).Name + "Id";
    }
}
