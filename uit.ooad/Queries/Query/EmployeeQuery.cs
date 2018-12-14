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
            Field<ListGraphType<EmployeeType>>(
                _List,
                "Trả về một danh sách các nhân viên",
                resolve: context => EmployeeBusiness.Get()
            );
            Field<EmployeeType>(
                _Item,
                "Trả về thông tin một nhân viên",
                _IdArgument(),
                context => EmployeeBusiness.Get(_GetId<string>(context))
            );
        }
    }
}
