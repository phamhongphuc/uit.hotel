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
            Field(x => x.IdentityCard).Description("Chứng minh nhân dân");
            Field(x => x.PhoneNumber).Description("Số điện thoại của nhân viên");
            Field(x => x.Address).Description("Địa chỉ của nhân viên");
            Field(x => x.Email).Description("Email của nhân viên");
            Field(x => x.Gender).Description("Giới tính của nhân viên");
            Field(x => x.Birthdate).Description("Ngày sinh của nhân viên");
            Field(x => x.StartingDate).Description("Ngày vào làm");
            Field(x => x.IsActive).Description("Tài khoản còn hiệu lực hay không");

            Field<NonNullGraphType<PositionType>>(
                nameof(Employee.Position),
                "Chức vụ",
                resolve: context => context.Source.Position);

            Field<ListGraphType<BillType>>(
                nameof(Employee.Bills),
                "Danh sách các Hóa đơn mà nhân viên tạo",
                resolve: context => context.Source.Bills.ToList());

            Field<ListGraphType<ReceiptType>>(
                nameof(Employee.Receipts),
                "Danh sách các Phiếu thu mà nhân viên tạo",
                resolve: context => context.Source.Receipts.ToList());

            Field<ListGraphType<RateType>>(
                nameof(Employee.Rates),
                "Danh sách các Giá cơ bản mà nhân viên tạo",
                resolve: context => context.Source.Rates.ToList());

            Field<ListGraphType<VolatilityRateType>>(
                nameof(Employee.VolatilityRates),
                "Danh sách các Giá biến động mà nhân viên tạo",
                resolve: context => context.Source.VolatilityRates.ToList());

            Field<ListGraphType<HouseKeepingType>>(
                nameof(Employee.HouseKeepings),
                "Danh sách các Phòng mà nhân viên dọn",
                resolve: context => context.Source.HouseKeepings.ToList());

            Field<ListGraphType<BookingType>>(
                nameof(Employee.Bookings),
                "Danh sách các Thông tin thuê phòng mà nhân viên tạo",
                resolve: context => context.Source.Bookings.ToList());
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
            Field(x => x.IdentityCard).Description("Chứng minh nhân dân");
            Field(x => x.PhoneNumber).Description("Số điện thoại của nhân viên");
            Field(x => x.Address).Description("Địa chỉ của nhân viên");
            Field(x => x.Email).Description("Email của nhân viên");
            Field(x => x.Birthdate).Description("Ngày sinh của nhân viên");
            Field(x => x.Gender).Description("Giới tính của nhân viên");
            Field(x => x.StartingDate).Description("Ngày vào làm");

            Field<PositionIdInput>(
                nameof(Employee.Position),
                "Loại chức vụ"
            );
        }
    }

    public class EmployeeUpdateInput : InputType<Employee>
    {
        public EmployeeUpdateInput()
        {
            Name = _Updation;
            Field(x => x.Id).Description("Id của nhân viên");
            Field(x => x.Name).Description("Tên nhân viên");
            Field(x => x.IdentityCard).Description("Chứng minh nhân dân");
            Field(x => x.Address).Description("Địa chỉ của nhân viên");
            Field(x => x.Birthdate).Description("Ngày sinh của nhân viên");
            Field(x => x.Email).Description("Email của nhân viên");
            Field(x => x.Gender).Description("Giới tính của nhân viên");
            Field(x => x.PhoneNumber).Description("Số điện thoại của nhân viên");
            Field(x => x.StartingDate).Description("Ngày vào làm");

            Field<PositionIdInput>(
                nameof(Employee.Position),
                "Loại chức vụ"
            );
        }
    }
}
