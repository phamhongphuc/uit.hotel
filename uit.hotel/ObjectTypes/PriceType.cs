using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class PriceType : ObjectGraphType<Price>
    {
        public PriceType()
        {
            Name = nameof(Price);
            Description = "Giá cố định của một loại phòng";

            Field(x => x.Id).Description("Id của giá");
            Field(x => x.HourPrice).Description("Giá giờ");
            Field(x => x.DayPrice).Description("Giá ngày");
            Field(x => x.NightPrice).Description("Giá đêm");
            Field(x => x.WeekPrice).Description("Giá tuần");
            Field(x => x.MonthPrice).Description("Giá tháng");
            Field(x => x.LateCheckOutFee).Description("Phí check-out muộn");
            Field(x => x.EarlyCheckInFee).Description("Phí check-out sớm");
            Field(x => x.EffectiveStartDate).Description("Ngày giá bắt đầu có hiệu lực");
            Field(x => x.CreateDate).Description("Ngày tạo giá");

            Field<NonNullGraphType<RoomKindType>>(
                nameof(Price.RoomKind),
                "Thuộc loại phòng",
                resolve: context => context.Source.RoomKind
            );
            Field<EmployeeType>(
                nameof(Price.Employee),
                "Nhân viên tạo giá",
                resolve: context => context.Source.Employee
            );
        }
    }

    public class PriceCreateInput : InputType<Price>
    {
        public PriceCreateInput()
        {
            Name = _Creation;
            Field(x => x.HourPrice).Description("Giá giờ");
            Field(x => x.DayPrice).Description("Giá ngày");
            Field(x => x.NightPrice).Description("Giá đêm");
            Field(x => x.WeekPrice).Description("Giá tuần");
            Field(x => x.MonthPrice).Description("Giá tháng");
            Field(x => x.LateCheckOutFee).Description("Phí check-out muộn");
            Field(x => x.EarlyCheckInFee).Description("Phí check-out sớm");
            Field(x => x.EffectiveStartDate).Description("Ngày giá bắt đầu có hiệu lực");

            Field<NonNullGraphType<RoomKindIdInput>>(
                nameof(Price.RoomKind),
                "Loại phòng"
            );
        }
    }

    public class PriceUpdateInput : InputType<Price>
    {
        public PriceUpdateInput()
        {
            Name = _Updation;
            Field(x => x.Id).Description("Id của giá cần cập nhật");
            Field(x => x.HourPrice).Description("Giá giờ");
            Field(x => x.DayPrice).Description("Giá ngày");
            Field(x => x.NightPrice).Description("Giá đêm");
            Field(x => x.WeekPrice).Description("Giá tuần");
            Field(x => x.MonthPrice).Description("Giá tháng");
            Field(x => x.LateCheckOutFee).Description("Phí check-out muộn");
            Field(x => x.EarlyCheckInFee).Description("Phí check-out sớm");
            Field(x => x.EffectiveStartDate).Description("Ngày giá bắt đầu có hiệu lực");

            Field<NonNullGraphType<RoomKindIdInput>>(
                nameof(Price.RoomKind),
                "Loại phòng"
            );
        }
    }
}
