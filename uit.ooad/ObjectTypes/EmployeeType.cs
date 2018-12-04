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
            Field(x => x.Position).Description("Chức vự");
            Field(x => x.Bills).Description("Danh sách các Hóa đơn mà nhân viên tạo");
            Field(x => x.Receipts).Description("Danh sách các Phiếu thu mà nhân viên tạo");
            Field(x => x.HouseKeepings).Description("Danh sách các Phòng mà nhân viên dọn");
            Field(x => x.Bookings).Description("Danh sách các Thông tin thuê phòng mà nhân viên tạo");
        }
    }
}
