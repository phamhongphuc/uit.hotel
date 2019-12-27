using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class PriceItemKindEnumType : EnumerationGraphType<PriceItemKindEnum>
    {
        public PriceItemKindEnumType()
        {
            Name = nameof(PriceItemKindEnum);
            Description = "Loại đơn vị giá";
        }
    }

    public class PriceItemType : ObjectGraphType<PriceItem>
    {
        public PriceItemType()
        {
            Name = nameof(PriceItem);
            Description = "Đơn vị giá";

            Field(x => x.Value).Description("Giá trị");
            Field(x => x.TimeSpan).Description("Thời gian");
            Field<NonNullGraphType<BookingType>>(
                nameof(PriceItem.Booking),
                "Đơn đặt phòng"
            );
            Field<NonNullGraphType<PriceItemKindEnumType>>(
                nameof(PriceItem.Kind),
                "Loại đơn vị giá"
            );
        }
    }
}
