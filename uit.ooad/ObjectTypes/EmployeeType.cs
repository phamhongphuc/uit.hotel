using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Name = "Employee";
            Description = "Một nhân viên trong khách sạn";

            Field(x => x.Id).Description("Id của nhân viên");
            Field(x => x.Password).Description("Mật khẩu của tài khoản nhân viên");
            Field(x => x.Name).Description("Tên nhân viên");
            Field(x => x.PhoneNumber).Description("Số điện thoại của nhân viên");
            Field(x => x.Address).Description("Địa chỉ của nhân viên");
            Field(x => x.Birthdate).Description("Ngày sinh của nhân viên");
            Field(x => x.StartingDate).Description("Ngày vào làm");
            // Field(x => x.Position).Description("Chức vự");
            Field<ListGraphType<BillType>>(
                "Bills",
                resolve: context => context.Source.Bills.ToList(),
                description: "Danh sách các Hóa đơn mà nhân viên tạo"
            );
            Field<ListGraphType<ReceiptType>>(
                "Receipts",
                resolve: context => context.Source.Receipts.ToList(),
                description: "Danh sách các Phiếu thu mà nhân viên tạo"
            );
            Field<ListGraphType<HouseKeepingType>>(
                "HouseKeepings",
                resolve: context => context.Source.HouseKeepings.ToList(),
                description: "Danh sách các Phòng mà nhân viên dọn"
            );
            Field<ListGraphType<BookingType>>(
                "Bookings",
                resolve: context => context.Source.Bookings.ToList(),
                description: "Danh sách các Thông tin thuê phòng mà nhân viên tạo"
            );
        }
    }
}
