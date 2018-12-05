using System.Linq;
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
            Field<ListGraphType<PatronType>>(
                "Patrons",
                resolve: context => context.Source.Patrons.ToList(),
                description: "Danh sách khách hàng yêu cầu đặt phòng"
            );
            Field<ListGraphType<HouseKeepingType>>(
                "HouseKeepings",
                resolve: context => context.Source.HouseKeepings.ToList(),
                description: "Danh sách nhân viên dọn phòng cho phòng đã đặt này"
            );
            Field<ListGraphType<ServicesDetailType>>(
                "ServicesDetails",
                resolve: context => context.Source.ServicesDetails.ToList(),
                description: "Danh sách chi tiết sử dụng dịch vụ của khách hàng"
            );
        }
    }
}