using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class RateType : ObjectGraphType<Rate>
    {
        public RateType()
        {
            Name = "Rate";
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
            // Field(x => x.RoomKind).Description("Thuộc loại phòng");
        }
    }
}
