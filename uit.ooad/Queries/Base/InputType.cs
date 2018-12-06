using GraphQL.Types;

namespace uit.ooad.Queries.Base
{
    public class InputType<TModel> : InputObjectGraphType<TModel>
    {
        public string _Creation => "Create" + typeof(TModel).Name + "Input";

        public string _Updation => "Update" + typeof(TModel).Name + "Input";

        public string _Id => typeof(TModel).Name + "Id";
    }
}
