using System.Linq;
using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class PositionType : ObjectGraphType<Position>
    {
        public PositionType()
        {
            Name = nameof(Position);
            Description = "Một chức vụ trong khách sạn";

            Field(x => x.Id).Description("Id của chức vụ");
            Field(x => x.Name).Description("Tên chức vụ");
            Field(x => x.IsActive).Description("Trạng thái kích hoạt/vô hiệu hóa chức vụ");

            Field(x => x.PermissionCleaning).Description("Quyền thao tác dọn phòng");

            Field(x => x.PermissionGetAccountingVoucher).Description("Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu)");
            Field(x => x.PermissionGetMap).Description("Quyền lấy thông tin tầng, phòng");
            Field(x => x.PermissionGetPatron).Description("Quyền lấy thông tin khách hàng");
            Field(x => x.PermissionGetPrice).Description("Quyền lấy thông tin giá cơ bản và giá biến động");
            Field(x => x.PermissionGetService).Description("Quyền lấy thông tin dịch vụ");

            Field(x => x.PermissionManageEmployee).Description("Quyền quản lý thông tin nhân viên");
            Field(x => x.PermissionManageMap).Description("Quyền chỉnh sửa sơ đồ");
            Field(x => x.PermissionManagePatron).Description("Quyền quản lý khách hàng");
            Field(x => x.PermissionManagePatronKind).Description("Quyền quản lý loại khách hàng");
            Field(x => x.PermissionManagePosition).Description("Quyền quản lý chức vụ");
            Field(x => x.PermissionManagePrice).Description("Quyền quản lý giá cơ bản và giá biến động");
            Field(x => x.PermissionManageRentingRoom).Description("Quyền quản lý thuê phòng");
            Field(x => x.PermissionManageService).Description("Quyền quản lý dịch vụ");

            Field<ListGraphType<EmployeeType>>(
                nameof(Position.Employees),
                "Danh sách các nhân viên thuộc quyền này",
                resolve: context => context.Source.Employees.ToList());

            Field<NonNullGraphType<IntGraphType>>(
                "countActiveEmployees",
                "Số nhân viên còn hoạt động",
                resolve: context => context.Source.Employees.Where(e => e.IsActive).Count());

            Field<NonNullGraphType<IntGraphType>>(
                "countInActiveEmployees",
                "Số nhân viên ngưng hoạt động",
                resolve: context => context.Source.Employees.Where(e => !e.IsActive).Count());

            Field<NonNullGraphType<IntGraphType>>(
                "countEmployees",
                "Số nhân viên",
                resolve: context => context.Source.Employees.Count());
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
            Field(x => x.PermissionCleaning).Description("Quyền thao tác dọn phòng");
            Field(x => x.PermissionGetAccountingVoucher)
               .Description("Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu)");
            Field(x => x.PermissionGetMap).Description("Quyền lấy thông tin tầng, phòng");
            Field(x => x.PermissionGetPatron).Description("Quyền lấy thông tin khách hàng");
            Field(x => x.PermissionGetPrice).Description("Quyền lấy thông tin giá cơ bản và giá biến động");
            Field(x => x.PermissionGetService).Description("Quyền lấy thông tin dịch vụ");

            Field(x => x.PermissionManageEmployee).Description("Quyền quản lý thông tin nhân viên");
            Field(x => x.PermissionManageRentingRoom).Description("Quyền quản lý thuê phòng");
            Field(x => x.PermissionManagePatron).Description("Quyền quản lý khách hàng");
            Field(x => x.PermissionManagePatronKind).Description("Quyền quản lý loại khách hàng");
            Field(x => x.PermissionManagePosition).Description("Quyền quản lý chức vụ");
            Field(x => x.PermissionManagePrice).Description("Quyền quản lý giá cơ bản và giá biến động");
            Field(x => x.PermissionManageService).Description("Quyền quản lý dịch vụ");
            Field(x => x.PermissionManageMap).Description("Quyền chỉnh sửa sơ đồ");
        }
    }

    public class PositionUpdateInput : InputType<Position>
    {
        public PositionUpdateInput()
        {
            Name = _Updation;

            Field(x => x.Id).Description("Id của chức vụ");
            Field(x => x.Name).Description("Tên chức vụ");
            Field(x => x.PermissionCleaning).Description("Quyền thao tác dọn phòng");
            Field(x => x.PermissionGetMap).Description("Quyền lấy thông tin tầng, phòng");
            Field(x => x.PermissionGetPatron).Description("Quyền lấy thông tin khách hàng");
            Field(x => x.PermissionGetPrice).Description("Quyền lấy thông tin giá cơ bản và giá biến động");
            Field(x => x.PermissionGetService).Description("Quyền lấy thông tin dịch vụ");
            Field(x => x.PermissionGetAccountingVoucher)
               .Description("Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu)");

            Field(x => x.PermissionManageEmployee).Description("Quyền quản lý thông tin nhân viên");
            Field(x => x.PermissionManageRentingRoom).Description("Quyền quản lý thuê phòng");
            Field(x => x.PermissionManageMap).Description("Quyền chỉnh sửa sơ đồ");
            Field(x => x.PermissionManagePatron).Description("Quyền quản lý khách hàng");
            Field(x => x.PermissionManagePatronKind).Description("Quyền quản lý loại khách hàng");
            Field(x => x.PermissionManagePosition).Description("Quyền quản lý chức vụ");
            Field(x => x.PermissionManagePrice).Description("Quyền quản lý giá cơ bản và giá biến động");
            Field(x => x.PermissionManageService).Description("Quyền quản lý dịch vụ");
        }
    }
}
