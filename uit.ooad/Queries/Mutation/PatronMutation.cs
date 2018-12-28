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
            Field<NonNullGraphType<PatronType>>(
                _Creation,
                "Tạo và trả về một khách hàng mới",
                _InputArgument<PatronCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePatrons,
                    context => PatronBusiness.Add(_GetInput(context))
                )
            );
            
            Field<NonNullGraphType<PatronType>>(
                _Updation,
                "Cập nhật và trả về một khách hàng vừa cập nhật",
                _InputArgument<PatronUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePatrons,
                    context => PatronBusiness.Update(_GetInput(context))
                )
            );
        }
    }
}
