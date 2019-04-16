using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
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
                    p => p.PermissionManagePatron,
                    context => PatronBusiness.Add(_GetInput(context))
                )
            );

            Field<NonNullGraphType<PatronType>>(
                _Updation,
                "Cập nhật và trả về một khách hàng vừa cập nhật",
                _InputArgument<PatronUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePatron,
                    context => PatronBusiness.Update(_GetInput(context))
                )
            );
        }
    }
}
