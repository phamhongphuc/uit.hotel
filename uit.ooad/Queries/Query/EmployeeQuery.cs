using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class EmployeeQuery : QueryType<Employee>
    {
        public EmployeeQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<EmployeeType>>>>(
                _List,
                "Trả về một danh sách các nhân viên",
                resolve: _CheckPermission_List(
                    p => p.PermissionManageEmployee,
                    context => EmployeeBusiness.Get()
                )
            );

            Field<NonNullGraphType<EmployeeType>>(
                _Item,
                "Trả về thông tin một nhân viên",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionManageEmployee,
                    context => EmployeeBusiness.Get(_GetId<string>(context))
                )
            );
        }
    }
}
