using GraphQL.Types;

namespace uit.ooad.Queries.Base
{
    public class QueryType<TModel> : ObjectGraphType
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

        public QueryArguments InputArgument<TInputGraphType>() where TInputGraphType : InputType<TModel>
        {
            return new QueryArguments(
                new QueryArgument<NonNullGraphType<TInputGraphType>> { Name = "input" }
            );
        }

        public QueryArguments IdArgument()
        {
            return new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
            );
        }

        public TModel GetInput(ResolveFieldContext<object> context)
        {
            return context.GetArgument<TModel>("input");
        }

        public TIntOrNumber GetId<TIntOrNumber>(ResolveFieldContext<object> context)
        {
            return context.GetArgument<TIntOrNumber>("id");
        }

        public int GetId(ResolveFieldContext<object> context)
        {
            return GetId<int>(context);
        }
    }
}
