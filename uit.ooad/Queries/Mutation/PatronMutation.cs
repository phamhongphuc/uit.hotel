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
                    p => p.PermissionCreatePatron,
                    context => PatronBusiness.Add(_GetInput(context))
                )
            );
        }
    }
}
