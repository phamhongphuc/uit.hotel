using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
{
    public class PositionType : ObjectGraphType<Position>
    {
        public PositionType()
        {
            Name = nameof(Position);
            Description = "Một chức vụ trong khách sạn";

            Field(x => x.Id).Description("Id của chức vụ");
            Field(x => x.Name).Description("Tên chức vụ");
            Field(x => x.PermissionCreateEmployee).Description("Quyền tạo tài khoản nhân viên");
            Field(x => x.PermissionCreatePatron).Description("Quyền tạo khách hàng");
            Field(x => x.PermissionCreateBill).Description("Quyền tạo hóa đơn");
            Field(x => x.PermissionCreateFloor).Description("Quyền tạo tầng");
            Field(x => x.PermissionCreatePosition).Description("Quyền tạo chức vụ");
            Field(x => x.PermissionCreateReceipt).Description("Quyền tạo phiếu thu");
            Field(x => x.PermissionCreateRoom).Description("Quyền tạo phòng");
            Field(x => x.PermissionCreateRate).Description("Quyền tạo giá cơ bản");
            Field(x => x.PermissionCreateVolatilityRate).Description("Quyền tạo giá biến động");

            Field<ListGraphType<EmployeeType>>(
                nameof(Position.Employees),
                resolve: context => context.Source.Employees.ToList(),
                description: "Danh sách các nhân viên thuộc quyền này"
            );
        }
    }

    public class PositionIdInput : InputType<Position>
    {
        public PositionIdInput()
        {
            Name = _Id;
            Description = "Input cho thông tin một chức vụ";

            Field(x => x.Id).Description("Id của chức vụ");
        }
    }

    public class PositionCreateInput : InputType<Position>
    {
        public PositionCreateInput()
        {
            Name = _Creation;

            Field(x => x.Id).Description("Id của chức vụ");
            Field(x => x.Name).Description("Tên chức vụ");
            Field(x => x.PermissionCreateEmployee).Description("Quyền tạo tài khoản nhân viên");
            Field(x => x.PermissionCreatePatron).Description("Quyền tạo khách hàng");
            Field(x => x.PermissionCreateBill).Description("Quyền tạo hóa đơn");
            Field(x => x.PermissionCreateFloor).Description("Quyền tạo tầng");
            Field(x => x.PermissionCreatePosition).Description("Quyền tạo chức vụ");
            Field(x => x.PermissionCreateReceipt).Description("Quyền tạo phiếu thu");
            Field(x => x.PermissionCreateRoom).Description("Quyền tạo phòng");
            Field(x => x.PermissionCreateRate).Description("Quyền tạo giá cơ bản");
            Field(x => x.PermissionCreateVolatilityRate).Description("Quyền tạo giá biến động");
            Field(x => x.PermissionCreateRoomKind).Description("Quyền tạo loại phòng");
        }
    }
}
