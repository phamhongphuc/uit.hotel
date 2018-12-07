using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Name = nameof(Employee);
            Description = "Một nhân viên trong khách sạn";

            Field(x => x.Id).Description("Id của nhân viên");
            Field(x => x.Password).Description("Mật khẩu của tài khoản nhân viên");
            Field(x => x.Name).Description("Tên nhân viên");
            Field(x => x.PhoneNumber).Description("Số điện thoại của nhân viên");
            Field(x => x.Address).Description("Địa chỉ của nhân viên");
            Field(x => x.Birthdate).Description("Ngày sinh của nhân viên");
            Field(x => x.StartingDate).Description("Ngày vào làm");

            Field<NonNullGraphType<PositionType>>(
                nameof(Employee.Position),
                resolve: context => context.Source.Position,
                description: "Chức vụ"
            );

            Field<ListGraphType<BillType>>(
                nameof(Employee.Bills),
                resolve: context => context.Source.Bills.ToList(),
                description: "Danh sách các Hóa đơn mà nhân viên tạo"
            );

            Field<ListGraphType<ReceiptType>>(
                nameof(Employee.Receipts),
                resolve: context => context.Source.Receipts.ToList(),
                description: "Danh sách các Phiếu thu mà nhân viên tạo"
            );

            Field<ListGraphType<HouseKeepingType>>(
                nameof(Employee.HouseKeepings),
                resolve: context => context.Source.HouseKeepings.ToList(),
                description: "Danh sách các Phòng mà nhân viên dọn"
            );

            Field<ListGraphType<BookingType>>(
                nameof(Employee.Bookings),
                resolve: context => context.Source.Bookings.ToList(),
                description: "Danh sách các Thông tin thuê phòng mà nhân viên tạo"
            );
        }
    }

    public class EmployeeIdInput : InputType<Employee>
    {
        public EmployeeIdInput()
        {
            Name = _Id;
            Description = "Input cho thông tin một nhân viên";
            Field(x => x.Id).Description("Id của một nhân viên");
        }
    }

    public class EmployeeCreateInput : InputType<Employee>
    {
        public EmployeeCreateInput()
        {
            Name = _Creation;
            Field(x => x.Id).Description("Id của nhân viên");
            Field(x => x.Password).Description("Mật khẩu của tài khoản nhân viên");
            Field(x => x.Name).Description("Tên nhân viên");
            Field(x => x.PhoneNumber).Description("Số điện thoại của nhân viên");
            Field(x => x.Address).Description("Địa chỉ của nhân viên");
            Field(x => x.Birthdate).Description("Ngày sinh của nhân viên");
            Field(x => x.StartingDate).Description("Ngày vào làm");

            Field<PositionIdInput>(
                "Position",
                "Loại chức vụ"
            );
        }
    }
}
