using System;
using System.ComponentModel;
using Realms;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Models
{
    public enum PriceVolatilityItemKindEnum
    {
        [Description("Giá biến động theo giờ")] Hour,
        [Description("Giá biến động theo đêm")] Night,
        [Description("Giá biến động theo ngày")] Day
    }

    public class PriceVolatilityItem : RealmObject
    {
        public Booking Booking { get; set; }
        public PriceVolatility PriceVolatility { get; set; }
        public DateTimeOffset Date { get; set; }

        [Ignored]
        public TimeSpan TimeSpan { get => new TimeSpan(TimeSpanRaw); set { TimeSpanRaw = value.Ticks; } }
        private long TimeSpanRaw { get; set; }

        [Ignored]
        public PriceVolatilityItemKindEnum Kind { get => (PriceVolatilityItemKindEnum)KindRaw; set { KindRaw = (int)value; } }
        private int KindRaw { get; set; }

        [Ignored]
        public long Value
        {
            get
            {
                switch (Kind)
                {
                    case PriceVolatilityItemKindEnum.Hour:
                        return TimeSpan.MultiplyByHourPrice(PriceVolatility.HourPrice);
                    case PriceVolatilityItemKindEnum.Night:
                        return PriceVolatility.NightPrice;
                    case PriceVolatilityItemKindEnum.Day:
                        return PriceVolatility.DayPrice;
                }
                return 0;
            }
        }
    }
}
