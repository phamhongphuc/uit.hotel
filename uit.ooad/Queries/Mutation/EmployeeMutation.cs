using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class EmployeeMutation : QueryType<Employee>
    {
        public EmployeeMutation()
        {
            Field<EmployeeType>(
                _Creation,
                "Tạo và trả về một nhân viên mới",
                InputArgument<EmployeeCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateEmployee,
                    context => EmployeeBusiness.Add(GetInput(context))
                )
            );
        }
    }
}
