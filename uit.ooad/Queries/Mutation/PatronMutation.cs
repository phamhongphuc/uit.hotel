using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class PatronMutation : QueryType<Patron>
    {
        public PatronMutation()
        {
            Field<PatronType>(
                _Creation,
                "Tạo và trả về một khách hàng mới",
                _InputArgument<PatronCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateOrUpdatePatron,
                    context => PatronBusiness.Add(_GetInput(context))
                )
            );
            Field<PatronType>(
                _Updation,
                "Cập nhật và trả về một khách hàng vừa cập nhật",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<PatronUpdateInput>> { Name = "patronUpdateInput" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "identification" }
                ),
                _CheckPermission(
                    p => p.PermissionCreateOrUpdatePatron,
                    context =>
                    {
                        var patronUpdateInput = context.GetArgument<Patron>("patronUpdateInput");
                        var identification = context.GetArgument<string>("identification");
                        
                        return PatronBusiness.Update(identification, patronUpdateInput);
                    }
                )
            );
        }
    }
}
