using System;
using GraphQL.Types;

namespace uit.ooad.Queries.Base
{
    public class QueryType<TModel> : ObjectGraphType
    {
        public string _Item => typeof(TModel).Name;

        public string _List => typeof(TModel).Name + "s";

        public string _Creation => "Create" + typeof(TModel).Name;

        public string _Deletion => "Delete" + typeof(TModel).Name;

        public string _Updation => "Update" + typeof(TModel).Name;

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

        public Func<ResolveFieldContext<object>, object> _Input
        => context => context.GetArgument<TModel>("input");

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
