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
            Field(x => x.PermissionGetGroundPlan).Description("Quyền lấy thông tin tầng, phòng");
            Field(x => x.PermissionManageRoomKind).Description("Quyền quản lý loại phòng");
            Field(x => x.PermissionGetRoomKind).Description("Quyền lấy thông tin loại phòng");
            Field(x => x.PermissionManageRate).Description("Quyền quản lý giá cơ bản và giá biến động");
            Field(x => x.PermissionGetRate).Description("Quyền lấy thông tin giá cơ bản và giá biến động");
            Field(x => x.PermissionCleaning).Description("Quyền thao tác dọn phòng");
            Field(x => x.PermissionGetHouseKeeping).Description("Quyền tra cứu lịch sử dọn phòng");
            Field(x => x.PermissionManageHiringRoom).Description("Quyền quản lý thuê phòng");
            Field(x => x.PermissionManagePatron).Description("Quyền quản lý khách hàng");
            Field(x => x.PermissionGetPatron).Description("Quyền lấy thông tin khách hàng");
            Field(x => x.PermissionManagePatronKind).Description("Quyền quản lý loại khách hàng");
            Field(x => x.PermissionGetPatronKind).Description("Quyền lấy thông tin loại khách hàng");
            Field(x => x.PermissionManagePosition).Description("Quyền quản lý chức vụ");
            Field(x => x.PermissionGetPosition).Description("Quyền lấy thông tin chức vụ");
            Field(x => x.PermissionManageEmployee).Description("Quyền quản lý thông tin nhân viên");
            Field(x => x.PermissionManageService).Description("Quyền quản lý dịch vụ");
            Field(x => x.PermissionGetService).Description("Quyền lấy thông tin dịch vụ");
            Field(x => x.PermissionGetVoucher).Description("Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu)");
            Field(x => x.IsActive).Description("Trạng thái kích hoạt/vô hiệu hóa chức vụ");

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
            Field(x => x.PermissionGetGroundPlan).Description("Quyền lấy thông tin tầng, phòng");
            Field(x => x.PermissionManageRoomKind).Description("Quyền quản lý loại phòng");
            Field(x => x.PermissionGetRoomKind).Description("Quyền lấy thông tin loại phòng");
            Field(x => x.PermissionManageRate).Description("Quyền quản lý giá cơ bản và giá biến động");
            Field(x => x.PermissionGetRate).Description("Quyền lấy thông tin giá cơ bản và giá biến động");
            Field(x => x.PermissionCleaning).Description("Quyền thao tác dọn phòng");
            Field(x => x.PermissionGetHouseKeeping).Description("Quyền tra cứu lịch sử dọn phòng");
            Field(x => x.PermissionManageHiringRoom).Description("Quyền quản lý thuê phòng");
            Field(x => x.PermissionManagePatron).Description("Quyền quản lý khách hàng");
            Field(x => x.PermissionGetPatron).Description("Quyền lấy thông tin khách hàng");
            Field(x => x.PermissionManagePatronKind).Description("Quyền quản lý loại khách hàng");
            Field(x => x.PermissionGetPatronKind).Description("Quyền lấy thông tin loại khách hàng");
            Field(x => x.PermissionManagePosition).Description("Quyền quản lý chức vụ");
            Field(x => x.PermissionGetPosition).Description("Quyền lấy thông tin chức vụ");
            Field(x => x.PermissionManageEmployee).Description("Quyền quản lý thông tin nhân viên");
            Field(x => x.PermissionManageService).Description("Quyền quản lý dịch vụ");
            Field(x => x.PermissionGetService).Description("Quyền lấy thông tin dịch vụ");
            Field(x => x.PermissionGetVoucher).Description("Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu)");
        }
    }

    public class PositionUpdateInput : InputType<Position>
    {
        public PositionUpdateInput()
        {
            Name = _Updation;

            Field(x => x.Id).Description("Id của chức vụ");
            Field(x => x.Name).Description("Tên chức vụ");
            Field(x => x.PermissionUpdateGroundPlan).Description("Quyền chỉnh sửa sơ đồ");
            Field(x => x.PermissionGetGroundPlan).Description("Quyền lấy thông tin tầng, phòng");
            Field(x => x.PermissionManageRoomKind).Description("Quyền quản lý loại phòng");
            Field(x => x.PermissionGetRoomKind).Description("Quyền lấy thông tin loại phòng");
            Field(x => x.PermissionManageRate).Description("Quyền quản lý giá cơ bản và giá biến động");
            Field(x => x.PermissionGetRate).Description("Quyền lấy thông tin giá cơ bản và giá biến động");
            Field(x => x.PermissionCleaning).Description("Quyền thao tác dọn phòng");
            Field(x => x.PermissionGetHouseKeeping).Description("Quyền tra cứu lịch sử dọn phòng");
            Field(x => x.PermissionManageHiringRoom).Description("Quyền quản lý thuê phòng");
            Field(x => x.PermissionManagePatron).Description("Quyền quản lý khách hàng");
            Field(x => x.PermissionGetPatron).Description("Quyền lấy thông tin khách hàng");
            Field(x => x.PermissionManagePatronKind).Description("Quyền quản lý loại khách hàng");
            Field(x => x.PermissionGetPatronKind).Description("Quyền lấy thông tin loại khách hàng");
            Field(x => x.PermissionManagePosition).Description("Quyền quản lý chức vụ");
            Field(x => x.PermissionGetPosition).Description("Quyền lấy thông tin chức vụ");
            Field(x => x.PermissionManageEmployee).Description("Quyền quản lý thông tin nhân viên");
            Field(x => x.PermissionManageService).Description("Quyền quản lý dịch vụ");
            Field(x => x.PermissionGetService).Description("Quyền lấy thông tin dịch vụ");
            Field(x => x.PermissionGetVoucher).Description("Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu)");
        }
    }
}
