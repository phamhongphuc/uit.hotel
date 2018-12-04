using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery()
        {
            FloorQuery();
            EmployeeQuery();
        }

        public void FloorQuery()
        {
            Field<ListGraphType<FloorType>>(
                "floors",
                "Trả về một danh sách các tầng",
                resolve: context => FloorBusiness.Get()
            );

            Field<FloorType>(
                "floor",
                "Trả về thông tin một tầng",
                new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                context => FloorBusiness.Get(context.GetArgument<int>("id"))
            );
        }

        public void EmployeeQuery()
        {
            Field<ListGraphType<EmployeeType>>(
                "Employees",
                "Trả về một danh sách các nhân viên",
                resolve: context => EmployeeBusiness.Get()
            );
        }
    }
}
