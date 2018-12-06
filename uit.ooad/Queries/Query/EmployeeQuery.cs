using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Query
{
    public class EmployeeeQuery : RootQueryGraphType
    {
        public EmployeeeQuery()
        {
            Field<ListGraphType<EmployeeType>>(
                GetList<Employee>(),
                "Trả về một danh sách các nhân viên",
                resolve: context => EmployeeBusiness.Get()
            );
        }
    }
}
