using System.Security.Claims;
using uit.ooad.Businesses;
using uit.ooad.GraphQL;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class EmployeeeMutation : QueryType<Employee>
    {
        public EmployeeeMutation()
        {
            Field<EmployeeType>(
                _Creation,
                "Tạo và trả về một nhân viên mới",
                InputArgument<EmployeeCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreatePatron,
                    context => EmployeeBusiness.Add(GetInput(context))
                )
            );
        }
    }
}
