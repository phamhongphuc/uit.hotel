using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class RateType : ObjectGraphType<Rate>
    {
        public RateType()
        {
            Name = nameof(Rate);
            Description = "Giá cố định của một loại phòng";

            Field(x => x.Id).Description("Id của giá");
            Field(x => x.DayRate).Description("Giá ngày");
            Field(x => x.NightRate).Description("Giá đêm");
            Field(x => x.WeekRate).Description("Giá tuần");
            Field(x => x.MonthRate).Description("Giá tháng");
            Field(x => x.LateCheckOutFee).Description("Phí check-out muộn");
            Field(x => x.EarlyCheckInFee).Description("Phí check-out sớm");
            Field(x => x.EffectiveStartDate).Description("Ngày giá bắt đầu có hiệu lực");
            Field(x => x.CreateDate).Description("Ngày tạo giá");

            Field<NonNullGraphType<RoomKindType>>(
                nameof(Rate.RoomKind),
                "Thuộc loại phòng",
                resolve: context => context.Source.RoomKind);

            Field<EmployeeType>(
                nameof(Rate.Employee),
                "Nhân viên tạo giá",
                resolve: context => context.Source.Employee);
        }
    }

    public class RateCreateInput : InputType<Rate>
    {
        public RateCreateInput()
        {
            Name = _Creation;
            Field(x => x.DayRate).Description("Giá ngày");
            Field(x => x.NightRate).Description("Giá đêm");
            Field(x => x.WeekRate).Description("Giá tuần");
            Field(x => x.MonthRate).Description("Giá tháng");
            Field(x => x.LateCheckOutFee).Description("Phí check-out muộn");
            Field(x => x.EarlyCheckInFee).Description("Phí check-out sớm");
            Field(x => x.EffectiveStartDate).Description("Ngày giá bắt đầu có hiệu lực");

            Field<NonNullGraphType<RoomKindIdInput>>(
                nameof(Rate.RoomKind),
                "Loại phòng"
            );
        }
    }

    public class RateUpdateInput : InputType<Rate>
    {
        public RateUpdateInput()
        {
            Name = _Updation;
            Field(x => x.Id).Description("Id của giá cần cập nhật");
            Field(x => x.DayRate).Description("Giá ngày");
            Field(x => x.NightRate).Description("Giá đêm");
            Field(x => x.WeekRate).Description("Giá tuần");
            Field(x => x.MonthRate).Description("Giá tháng");
            Field(x => x.LateCheckOutFee).Description("Phí check-out muộn");
            Field(x => x.EarlyCheckInFee).Description("Phí check-out sớm");
            Field(x => x.EffectiveStartDate).Description("Ngày giá bắt đầu có hiệu lực");

            Field<RoomKindIdInput>(
                nameof(Rate.RoomKind),
                "Loại phòng"
            );
        }
    }
}
