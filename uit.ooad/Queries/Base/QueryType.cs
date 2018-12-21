using System;
using System.Threading.Tasks;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Authentication;

namespace uit.ooad.Queries.Base
{
    public abstract class QueryType<TModel> : ObjectGraphType
    {
        public string _Item => typeof(TModel).Name;

        public string _List => typeof(TModel).Name + "s";

        public string _Finding => "Finding" + typeof(TModel).Name;

        public string _Creation => "Create" + typeof(TModel).Name;

        public string _Deletion => "Delete" + typeof(TModel).Name;

        public string _Updation => "Update" + typeof(TModel).Name;

        public string _SetIsActive => "SetIsActive" + typeof(TModel).Name;

        public QueryArguments _InputArgument<TInputGraphType>() where TInputGraphType : InputType<TModel>
            => new QueryArguments(new QueryArgument<NonNullGraphType<TInputGraphType>> { Name = "input" });

        public QueryArguments _IdArgument()
            => new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" });

        public TModel _GetInput(ResolveFieldContext<object> context)
            => context.GetArgument<TModel>("input");

        public T _GetId<T>(ResolveFieldContext<object> context)
            => context.GetArgument<T>("id");

        public Func<ResolveFieldContext<object>, object> _CheckPermission(
            Func<Position, bool> getPermission,
            Func<ResolveFieldContext<object>, Task<TModel>> resolver
        )
            => context =>
            {
                AuthenticationHelper.HasPermission(context, getPermission);
                return resolver(context);
            };
            
        public Func<ResolveFieldContext<object>, object> _CheckPermission<TReturn>(
        Func<Position, bool> getPermission,
        Func<ResolveFieldContext<object>, TReturn> resolver
    )
        => context =>
        {
            AuthenticationHelper.HasPermission(context, getPermission);
            return resolver(context);
        };
    }
}
