using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class BookingType : ObjectGraphType<Booking>
    {
        public BookingType()
        {
            Name = "Booking";
            Description = "Một đơn đặt phòng trước của khách hàng";

            Field(x => x.Id).Description("Id của đơn đặt phòng");
            Field(x => x.CheckInTime).Description("Thời điểm nhận phòng dự kiến của khách hàng");
            Field(x => x.CheckOutTime).Description("Thời điểm trả phòng dự kiến của khách hàng");
            Field(x => x.CreateTime).Description("Thời điểm tạo đơn đặt phòng");
            Field(x => x.Status).Description("Trạng thái của đơn đặt phòng");
            Field(x => x.Employee).Description("Nhân viên thực hiện giao dịch nhận đặt phòng từ khách hàng");
            Field(x => x.Bill).Description("Thông tin hóa đơn của đơn đặt phòng");
            Field(x => x.Room).Description("Phòng khách hàng chọn đặt trước");
            // Field(x => x.Patrons).Description("Danh sách khách hàng yêu cầu đặt phòng");
            // Field(x => x.HouseKeepings).Description("Danh sách nhân viên dọn phòng cho phòng đã đặt này");
            // Field(x => x.ServicesDetails).Description("Danh sách chi tiết sử dụng dịch vụ của khách hàng");
        }
    }
}