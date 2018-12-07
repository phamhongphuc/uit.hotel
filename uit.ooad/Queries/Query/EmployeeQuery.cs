using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Query
{
    public class EmployeeeQuery : QueryType<Employee>
    {
        public EmployeeeQuery()
        {
            Field<ListGraphType<EmployeeType>>(
                _List,
                "Trả về một danh sách các nhân viên",
                resolve: context => EmployeeBusiness.Get()
            );
        }
    }
}
