using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Authentication;

namespace uit.hotel.Queries.Base
{
    public abstract class QueryType<TModel> : ObjectGraphType
    {
        public string _Item => typeof(TModel).Name;

        public string _List => typeof(TModel).Name + "s";

        public string _Finding => "Finding" + typeof(TModel).Name;

        public string _Creation => "Create" + typeof(TModel).Name;

        public string _Deletion => "Delete" + typeof(TModel).Name;

        public string _Updation => "Update" + typeof(TModel).Name;

        public string _UpdationField(string field) => "Update" + typeof(TModel).Name + field;

        public string _SetIsActive => "SetIsActive" + typeof(TModel).Name;

        public QueryArguments _InputArgument<TInputGraphType>() where TInputGraphType : InputType<TModel>
            => new QueryArguments(new QueryArgument<NonNullGraphType<TInputGraphType>> { Name = "input" });

        public QueryArguments _IdArgument()
            => new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" });

        public TModel _GetInput(ResolveFieldContext<object> context)
            => context.GetArgument<TModel>("input");

        public T _GetId<T>(ResolveFieldContext<object> context)
            => context.GetArgument<T>("id");

        private Func<ResolveFieldContext<object>, object> _CheckPermissionWithType<TType>(
            Func<Position, bool> getPermission,
            Func<ResolveFieldContext<object>, TType> resolver
        )
            => context =>
            {
                AuthenticationHelper.HasPermission(context, getPermission);
                return resolver(context);
            };

        public Func<ResolveFieldContext<object>, object> _CheckPermission_TaskObject(
            Func<Position, bool> getPermission,
            Func<ResolveFieldContext<object>, Task<TModel>> resolver
        ) => _CheckPermissionWithType(getPermission, resolver);

        public Func<ResolveFieldContext<object>, object> _CheckPermission_Object(
            Func<Position, bool> getPermission,
            Func<ResolveFieldContext<object>, TModel> resolver
        ) => _CheckPermissionWithType(getPermission, resolver);

        public Func<ResolveFieldContext<object>, object> _CheckPermission_String(
            Func<Position, bool> getPermission,
            Func<ResolveFieldContext<object>, string> resolver
        ) => _CheckPermissionWithType(getPermission, resolver);

        public Func<ResolveFieldContext<object>, object> _CheckPermission_List(
            Func<Position, bool> getPermission,
            Func<ResolveFieldContext<object>, IEnumerable<TModel>> resolver
        ) => _CheckPermissionWithType(getPermission, resolver);
    }
}
