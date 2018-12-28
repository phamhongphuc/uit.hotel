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
            Field(x => x.PermissionReferDebt).Description("Quyền tra cứu công nợ");
            Field(x => x.PermissionChangePersonalPassword).Description("Quyền thay đổi mật khẩu cá nhân");
            Field(x => x.PermissionManagePositions).Description("Quyền quản lý chức vụ");
            Field(x => x.PermissionManageEmployees).Description("Quyền quản lý thông tin nhân viên");
            Field(x => x.PermissionReferRevenues).Description("Quyền xem thống kê và chi tiết doanh thu");
            Field(x => x.PermissionHandleBills).Description("Quyền thao tác hóa đơn");
            Field(x => x.PermissionGetRooms).Description("Quyền lấy danh sách phòng và hiện trạng từng phòng");
            Field(x => x.PermissionManageHiringRooms).Description("Quyền quản lý thuê phòng");
            Field(x => x.PermissionGetHouseKeeping).Description("Quyền tra cứu lịch sử dọn phòng");
            Field(x => x.PermissionManagePatrons).Description("Quyền quản lý khách hàng");
            Field(x => x.PermissionManagePatronKinds).Description("Quyền quản lý loại khách hàng");
            Field(x => x.PermissionCleaning).Description("Quyền thao tác dọn phòng");

            Field(x => x.PermissionCreateOrUpdatePatron).Description("Quyền tạo hoặc chỉnh sửa khách hàng");
            Field(x => x.PermissionCreateOrUpdateEmployee).Description("Quyền tạo hoặc chỉnh sửa tài khoản nhân viên");
            Field(x => x.PermissionCreatePatronKind).Description("Quyền tạo loại khách hàng");
            Field(x => x.PermissionCreateBill).Description("Quyền tạo hóa đơn");
            Field(x => x.PermissionCreatePosition).Description("Quyền tạo chức vụ");
            Field(x => x.PermissionCreateReceipt).Description("Quyền tạo phiếu thu");
            Field(x => x.PermissionManageRoomKind).Description("Quyền quản lý loại phòng");
            Field(x => x.PermissionManageRate).Description("Quyền quản lý giá cơ bản và giá biến động");
            Field(x => x.PermissionManageService).Description("Quyền quản lý dịch vụ");
            Field(x => x.PermissionCreateServicesDetail).Description("Quyền tạo chi tiết dịch vụ");
            Field(x => x.PermissionCreateBooking).Description("Quyền tạo đơn đặt phòng");

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
            Field(x => x.PermissionReferDebt).Description("Quyền tra cứu công nợ");
            Field(x => x.PermissionChangePersonalPassword).Description("Quyền thay đổi mật khẩu cá nhân");
            Field(x => x.PermissionManagePositions).Description("Quyền quản lý chức vụ");
            Field(x => x.PermissionManageEmployees).Description("Quyền quản lý thông tin nhân viên");
            Field(x => x.PermissionReferRevenues).Description("Quyền xem thống kê và chi tiết doanh thu");
            Field(x => x.PermissionHandleBills).Description("Quyền thao tác hóa đơn");
            Field(x => x.PermissionGetRooms).Description("Quyền lấy danh sách phòng và hiện trạng từng phòng");
            Field(x => x.PermissionManageHiringRooms).Description("Quyền quản lý thuê phòng");
            Field(x => x.PermissionGetHouseKeeping).Description("Quyền tra cứu lịch sử dọn phòng");
            Field(x => x.PermissionManagePatrons).Description("Quyền quản lý khách hàng");
            Field(x => x.PermissionManagePatronKinds).Description("Quyền quản lý loại khách hàng");
            Field(x => x.PermissionCleaning).Description("Quyền thao tác dọn phòng");

            Field(x => x.PermissionCreateOrUpdatePatron).Description("Quyền tạo hoặc chỉnh sửa khách hàng");
            Field(x => x.PermissionCreateOrUpdateEmployee).Description("Quyền tạo hoặc chỉnh sửa tài khoản nhân viên");
            Field(x => x.PermissionCreatePatronKind).Description("Quyền tạo loại khách hàng");
            Field(x => x.PermissionCreateBill).Description("Quyền tạo hóa đơn");
            Field(x => x.PermissionCreatePosition).Description("Quyền tạo chức vụ");
            Field(x => x.PermissionCreateReceipt).Description("Quyền tạo phiếu thu");
            Field(x => x.PermissionManageRoomKind).Description("Quyền quản lý loại phòng");
            Field(x => x.PermissionManageRate).Description("Quyền quản lý giá cơ bản và giá biến động");
            Field(x => x.PermissionManageService).Description("Quyền quản lý dịch vụ");
            Field(x => x.PermissionCreateServicesDetail).Description("Quyền tạo chi tiết dịch vụ");
            Field(x => x.PermissionCreateBooking).Description("Quyền tạo đơn đặt phòng");
        }
    }
}
