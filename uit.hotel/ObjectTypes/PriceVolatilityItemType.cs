using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class PriceVolatilityItemKindEnumType : EnumerationGraphType<PriceVolatilityItemKindEnum>
    {
        public PriceVolatilityItemKindEnumType()
        {
            Name = nameof(PriceVolatilityItemKindEnum);
            Description = "Loại đơn vị giá biến động";
        }
    }
    public class PriceVolatilityItemType : ObjectGraphType<PriceVolatilityItem>
    {
        public PriceVolatilityItemType()
        {
            Name = nameof(PriceVolatilityItem);
            Description = "Đơn vị giá biến động";

            Field(x => x.Value).Description("Giá trị");
            Field(x => x.TimeSpan).Description("Khoảng thời gian");
            Field(x => x.Date).Description("Mốc thời gian");

            Field<NonNullGraphType<BookingType>>(
                nameof(PriceVolatilityItem.Booking),
                "Đơn đặt phòng"
            );
            Field<NonNullGraphType<PriceVolatilityType>>(
                nameof(PriceVolatilityItem.PriceVolatility),
                "Đối tượng giá biến động"
            );
            Field<NonNullGraphType<PriceVolatilityItemKindEnumType>>(
                nameof(PriceVolatilityItem.Kind),
                "Loại đơn vị giá"
            );
        }
    }
}
