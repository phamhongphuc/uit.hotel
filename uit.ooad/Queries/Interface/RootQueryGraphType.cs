using GraphQL.Types;

namespace uit.ooad.Queries.Interface
{
    public class RootQueryGraphType<TModel> : ObjectGraphType
    {
        public string _Item
        {
            get => typeof(TModel).Name;
        }

        public string _List
        {
            get => typeof(TModel).Name + "s";
        }

        public string _Creation
        {
            get => "Create" + typeof(TModel).Name;
        }

        public string _Deletion
        {
            get => "Delete" + typeof(TModel).Name;
        }

        public string _Updation
        {
            get => "Update" + typeof(TModel).Name;
        }

        public QueryArguments InputArgument<TInputGraphType>() where TInputGraphType : RootInputGraphType<TModel>
        {
            return new QueryArguments(
                new QueryArgument<NonNullGraphType<TInputGraphType>> { Name = "input" }
            );
        }
    }
}
