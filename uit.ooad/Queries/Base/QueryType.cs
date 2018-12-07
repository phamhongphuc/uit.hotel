using System;
using System.Threading.Tasks;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Authentication;

namespace uit.ooad.Queries.Base
{
    public abstract class QueryType<TModel> : ObjectGraphType
    {
        private AuthenticationHelper _Authentication => AuthenticationHelper.Instance;

        public string _Item => typeof(TModel).Name;

        public string _List => typeof(TModel).Name + "s";

        public string _Creation => "Create" + typeof(TModel).Name;

        public string _Deletion => "Delete" + typeof(TModel).Name;

        public string _Updation => "Update" + typeof(TModel).Name;

        public Func<ResolveFieldContext<object>, object> _Input
            => context => context.GetArgument<TModel>("input");

        public QueryArguments InputArgument<TInputGraphType>() where TInputGraphType : InputType<TModel>
            => new QueryArguments(new QueryArgument<NonNullGraphType<TInputGraphType>> { Name = "input" });

        public QueryArguments IdArgument()
            => new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" });

        public TModel GetInput(ResolveFieldContext<object> context)
            => context.GetArgument<TModel>("input");

        public TIntOrNumber GetId<TIntOrNumber>(ResolveFieldContext<object> context)
            => context.GetArgument<TIntOrNumber>("id");

        public int GetId(ResolveFieldContext<object> context)
            => GetId<int>(context);

        public Func<ResolveFieldContext<object>, object> _CheckPermission(
            Func<Position, Boolean> getPermission,
            Func<ResolveFieldContext<object>, Task<TModel>> resolver
        )
            => context =>
            {
                _Authentication.HasPermission(context, getPermission);
                return resolver(context);
            };
    }
}
