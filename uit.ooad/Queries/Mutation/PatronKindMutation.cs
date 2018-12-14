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
            Field<PatronKindType>(
                _Creation,
                "Tạo và trả về một loại khách hàng mới",
                InputArgument<PatronKindCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreatePatronKind,
                    context => PatronKindBusiness.Add(GetInput(context))
                )
            );
        }
    }
}
