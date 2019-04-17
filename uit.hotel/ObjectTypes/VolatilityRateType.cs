using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class VolatilityRateType : ObjectGraphType<VolatilityRate>
    {
        public VolatilityRateType()
        {
            Name = nameof(VolatilityRate);
            Description = "Giá biến động của một loại phòng";

            Field(x => x.Id).Description("Id của giá");
            Field(x => x.DayRate).Description("Giá ngày");
            Field(x => x.NightRate).Description("Giá đêm");
            Field(x => x.WeekRate).Description("Giá tuần");
            Field(x => x.MonthRate).Description("Giá tháng");
            Field(x => x.LateCheckOutFee).Description("Phí check-out muộn");
            Field(x => x.EarlyCheckInFee).Description("Phí check-out sớm");
            Field(x => x.EffectiveStartDate).Description("Ngày giá bắt đầu có hiệu lực");
            Field(x => x.EffectiveEndDate).Description("Ngày giá hết hiệu lực");
            Field(x => x.EffectiveOnMonday).Description("Giá có hiệu lực vào ngày Thứ 2");
            Field(x => x.EffectiveOnTuesday).Description("Giá có hiệu lực vào ngày Thứ 3");
            Field(x => x.EffectiveOnWednesday).Description("Giá có hiệu lực vào ngày Thứ 4");
            Field(x => x.EffectiveOnThursday).Description("Giá có hiệu lực vào ngày Thứ 5");
            Field(x => x.EffectiveOnFriday).Description("Giá có hiệu lực vào ngày Thứ 6");
            Field(x => x.EffectiveOnSaturday).Description("Giá có hiệu lực vào ngày Thứ 7");
            Field(x => x.EffectiveOnSunday).Description("Giá có hiệu lực vào ngày Chủ Nhật");
            Field(x => x.CreateDate).Description("Ngày tạo giá");

            Field<NonNullGraphType<RoomKindType>>(
                nameof(VolatilityRate.RoomKind),
                "Thuộc loại phòng",
                resolve: context => context.Source.RoomKind);

            Field<EmployeeType>(
                nameof(VolatilityRate.Employee),
                "Nhân viên tạo giá",
                resolve: context => context.Source.Employee);
        }
    }

    public class VolatilityRateCreateInput : InputType<VolatilityRate>
    {
        public VolatilityRateCreateInput()
        {
            Name = _Creation;
            Field(x => x.DayRate).Description("Giá ngày");
            Field(x => x.NightRate).Description("Giá đêm");
            Field(x => x.WeekRate).Description("Giá tuần");
            Field(x => x.MonthRate).Description("Giá tháng");
            Field(x => x.LateCheckOutFee).Description("Phí check-out muộn");
            Field(x => x.EarlyCheckInFee).Description("Phí check-out sớm");
            Field(x => x.EffectiveStartDate).Description("Ngày giá bắt đầu có hiệu lực");
            Field(x => x.EffectiveEndDate).Description("Ngày giá hết hiệu lực");
            Field(x => x.EffectiveOnMonday).Description("Giá có hiệu lực vào ngày Thứ 2");
            Field(x => x.EffectiveOnTuesday).Description("Giá có hiệu lực vào ngày Thứ 3");
            Field(x => x.EffectiveOnWednesday).Description("Giá có hiệu lực vào ngày Thứ 4");
            Field(x => x.EffectiveOnThursday).Description("Giá có hiệu lực vào ngày Thứ 5");
            Field(x => x.EffectiveOnFriday).Description("Giá có hiệu lực vào ngày Thứ 6");
            Field(x => x.EffectiveOnSaturday).Description("Giá có hiệu lực vào ngày Thứ 7");
            Field(x => x.EffectiveOnSunday).Description("Giá có hiệu lực vào ngày Chủ Nhật");

            Field<NonNullGraphType<RoomKindIdInput>>(
                nameof(VolatilityRate.RoomKind),
                "Loại phòng"
            );
        }
    }

    public class VolatilityRateUpdateInput : InputType<VolatilityRate>
    {
        public VolatilityRateUpdateInput()
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
            Field(x => x.EffectiveEndDate).Description("Ngày giá hết hiệu lực");
            Field(x => x.EffectiveOnMonday).Description("Giá có hiệu lực vào ngày Thứ 2");
            Field(x => x.EffectiveOnTuesday).Description("Giá có hiệu lực vào ngày Thứ 3");
            Field(x => x.EffectiveOnWednesday).Description("Giá có hiệu lực vào ngày Thứ 4");
            Field(x => x.EffectiveOnThursday).Description("Giá có hiệu lực vào ngày Thứ 5");
            Field(x => x.EffectiveOnFriday).Description("Giá có hiệu lực vào ngày Thứ 6");
            Field(x => x.EffectiveOnSaturday).Description("Giá có hiệu lực vào ngày Thứ 7");
            Field(x => x.EffectiveOnSunday).Description("Giá có hiệu lực vào ngày Chủ Nhật");

            Field<NonNullGraphType<RoomKindIdInput>>(
                nameof(VolatilityRate.RoomKind),
                "Loại phòng"
            );
        }
    }
}