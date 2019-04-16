using GraphQL.Types;

namespace uit.hotel.Queries.Base
{
    public class InputType<TModel> : InputObjectGraphType<TModel>
    {
        public string _CreationOrUpdation => typeof(TModel).Name + "CreateOrUpdateInput";

        public string _Creation => typeof(TModel).Name + "CreateInput";

        public string _Updation => typeof(TModel).Name + "UpdateInput";

        public string _Id => typeof(TModel).Name + "Id";
    }
}
