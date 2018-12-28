using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class PatronKindMutation : QueryType<PatronKind>
    {
        public PatronKindMutation()
        {
            Field<NonNullGraphType<PatronKindType>>(
                _Creation,
                "Tạo và trả về một loại khách hàng mới",
                _InputArgument<PatronKindCreateInput>(),
                _CheckPermission_Object(
                    p => p.PermissionManagePatronKinds,
                    context => PatronKindBusiness.Add(_GetInput(context))
                )
            );
        }
    }
}
