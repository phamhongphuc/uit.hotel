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
            Field(x => x.PermissionUpdateGroundPlan).Description("Quyền chỉnh sửa sơ đồ");

            Field(x => x.PermissionCreateOrUpdatePatron).Description("Quyền tạo hoặc chỉnh sửa khách hàng");
            Field(x => x.PermissionCreateOrUpdateEmployee).Description("Quyền tạo hoặc chỉnh sửa tài khoản nhân viên");
            Field(x => x.PermissionCreatePatronKind).Description("Quyền tạo loại khách hàng");
            Field(x => x.PermissionCreateBill).Description("Quyền tạo hóa đơn");
            Field(x => x.PermissionCreatePosition).Description("Quyền tạo chức vụ");
            Field(x => x.PermissionCreateReceipt).Description("Quyền tạo phiếu thu");
            Field(x => x.PermissionCreateOrUpdateRoomKind).Description("Quyền tạo hoặc chỉnh sửa loại phòng");
            Field(x => x.PermissionCreateOrUpdateRate).Description("Quyền tạo giá cơ bản");
            Field(x => x.PermissionCreateVolatilityRate).Description("Quyền tạo giá biến động");
            Field(x => x.PermissionCreateOrUpdateService).Description("Quyền tạo dịch vụ");
            Field(x => x.PermissionCreateServicesDetail).Description("Quyền tạo chi tiết dịch vụ");
            Field(x => x.PermissionCreateBooking).Description("Quyền tạo đơn đặt phòng");
            Field(x => x.PermissionCreateHouseKeeping).Description("Quyền tạo công việc dọn phòng");

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

            Field(x => x.Name).Description("Tên chức vụ");
            Field(x => x.PermissionUpdateGroundPlan).Description("Quyền chỉnh sửa sơ đồ");

            Field(x => x.PermissionCreateOrUpdatePatron).Description("Quyền tạo hoặc chỉnh sửa khách hàng");
            Field(x => x.PermissionCreateOrUpdateEmployee).Description("Quyền tạo hoặc chỉnh sửa tài khoản nhân viên");
            Field(x => x.PermissionCreatePatronKind).Description("Quyền tạo loại khách hàng");
            Field(x => x.PermissionCreateBill).Description("Quyền tạo hóa đơn");
            Field(x => x.PermissionCreatePosition).Description("Quyền tạo chức vụ");
            Field(x => x.PermissionCreateReceipt).Description("Quyền tạo phiếu thu");
            Field(x => x.PermissionCreateOrUpdateRoomKind).Description("Quyền tạo hoặc chỉnh sửa loại phòng");
            Field(x => x.PermissionCreateOrUpdateRate).Description("Quyền tạo giá cơ bản");
            Field(x => x.PermissionCreateVolatilityRate).Description("Quyền tạo giá biến động");
            Field(x => x.PermissionCreateOrUpdateService).Description("Quyền tạo và cập nhật dịch vụ");
            Field(x => x.PermissionCreateServicesDetail).Description("Quyền tạo chi tiết dịch vụ");
            Field(x => x.PermissionCreateBooking).Description("Quyền tạo đơn đặt phòng");
            Field(x => x.PermissionCreateHouseKeeping).Description("Quyền tạo công việc dọn phòng");
        }
    }
}
