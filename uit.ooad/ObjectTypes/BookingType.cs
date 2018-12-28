using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
{
    public class BookingType : ObjectGraphType<Booking>
    {
        public BookingType()
        {
            Name = nameof(Booking);
            Description = "Một thông tin thuê phòng của khách hàng";

            Field(x => x.Id).Description("Id của thông tin thuê phòng");
            Field(x => x.BookCheckInTime, true).Description("Thời điểm nhận phòng dự kiến của khách hàng");
            Field(x => x.BookCheckOutTime, true).Description("Thời điểm trả phòng dự kiến của khách hàng");
            Field(x => x.RealCheckInTime, true).Description("Thời điểm nhận phòng của khách hàng");
            Field(x => x.RealCheckOutTime, true).Description("Thời điểm trả phòng của khách hàng");
            Field(x => x.CreateTime).Description("Thời điểm tạo thông tin thuê phòng");
            Field(x => x.Status).Description("Trạng thái của thông tin thuê phòng");

            Field<EmployeeType>(
                nameof(Booking.EmployeeBooking),
                resolve: context => context.Source.EmployeeBooking,
                description: "Nhân viên thực hiện giao dịch nhận đặt phòng từ khách hàng"
            );
            Field<EmployeeType>(
                nameof(Booking.EmployeeCheckIn),
                resolve: context => context.Source.EmployeeCheckIn,
                description: "Nhân viên thực hiện giao dịch nhận đặt phòng từ khách hàng"
            );
            Field<EmployeeType>(
                nameof(Booking.EmployeeCheckOut),
                resolve: context => context.Source.EmployeeCheckOut,
                description: "Nhân viên thực hiện giao dịch nhận đặt phòng từ khách hàng"
            );

            Field<NonNullGraphType<BillType>>(
                nameof(Booking.Bill),
                resolve: context => context.Source.Bill,
                description: "Thông tin hóa đơn của thông tin thuê phòng"
            );
            Field<NonNullGraphType<RoomType>>(
                nameof(Booking.Room),
                resolve: context => context.Source.Room,
                description: "Phòng khách hàng chọn đặt trước"
            );

            Field<NonNullGraphType<ListGraphType<PatronType>>>(
                nameof(Booking.Patrons),
                resolve: context => context.Source.Patrons.ToList(),
                description: "Danh sách khách hàng yêu cầu đặt phòng"
            );

            Field<ListGraphType<HouseKeepingType>>(
                nameof(Booking.HouseKeepings),
                resolve: context => context.Source.HouseKeepings.ToList(),
                description: "Danh sách nhân viên dọn phòng cho phòng đã đặt này"
            );

            Field<ListGraphType<ServicesDetailType>>(
                nameof(Booking.ServicesDetails),
                resolve: context => context.Source.ServicesDetails.ToList(),
                description: "Danh sách chi tiết sử dụng dịch vụ của khách hàng"
            );
        }
    }

    public class BookingIdInput : InputType<Booking>
    {
        public BookingIdInput()
        {
            Name = _Id;
            Description = "Input cho một thông tin một đơn đặt phòng";
            Field(x => x.Id).Description("Id của một đơn đặt phòng");
        }
    }

    public class BookingCreateInput : InputType<Booking>
    {
        public BookingCreateInput()
        {
            Name = _Creation;

            Field(x => x.BookCheckInTime, true).Description("Thời điểm nhận phòng dự kiến của khách hàng");
            Field(x => x.BookCheckOutTime, true).Description("Thời điểm trả phòng dự kiến của khách hàng");

            Field<NonNullGraphType<RoomIdInput>>(
                nameof(Booking.Room),
                "Phòng khách hàng chọn đặt trước"
            );
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PatronIdInput>>>>(
                nameof(Booking.ListOfPatrons),
                "Danh sách khách hàng"
            );
        }
    }
}
