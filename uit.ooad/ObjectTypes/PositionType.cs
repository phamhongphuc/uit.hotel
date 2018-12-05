using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class PositionType : ObjectGraphType<Position>
    {
        public PositionType()
        {
            Name = "Position";
            Description = "Một chức vụ trong khách sạn";

            Field(x => x.Id).Description("Id của chức vụ");
            Field(x => x.Name).Description("Tên chức vụ");
            // Field(x => x.PermissionCreateAccount).Description("Quyền tạo tài khoản");

            Field<ListGraphType<EmployeeType>>("employees", resolve: context => context.Source.Employees.ToList(),
                                               description: "Danh sách các nhân viên thuộc quyền này");
        }
    }
}
