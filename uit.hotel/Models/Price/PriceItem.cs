using System;
using System.Collections.Generic;
using System.ComponentModel;
using Realms;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Models
{
    public enum PriceItemKindEnum
    {
        [Description("Giá theo giờ")] Hour,
        [Description("Giá theo đêm")] Night,
        [Description("Giá theo ngày")] Day,
        [Description("Giá theo tuần")] Week,
        [Description("Giá theo tháng")] Month
    }

    public class PriceItem : RealmObject
    {
        public Booking Booking { get; set; }

        [Ignored]
        public TimeSpan TimeSpan { get => new TimeSpan(TimeSpanRaw); set { TimeSpanRaw = value.Ticks; } }
        private long TimeSpanRaw { get; set; }

        [Ignored]
        public PriceItemKindEnum Kind { get => (PriceItemKindEnum)KindRaw; set { KindRaw = (int)value; } }
        private int KindRaw { get; set; }

        // Calculated Value
        [Ignored]
        public long Value
        {
            get
            {
                switch (Kind)
                {
                    case PriceItemKindEnum.Hour:
                        return TimeSpan.MultiplyByHourPrice(Booking.Price.HourPrice);
                    case PriceItemKindEnum.Night:
                        return Booking.Price.NightPrice;
                    case PriceItemKindEnum.Day:
                        return Booking.Price.DayPrice * (TimeSpan.Days + 1);
                    case PriceItemKindEnum.Week:
                        return Booking.Price.WeekPrice * ((TimeSpan.Days + 1) / 7);
                    case PriceItemKindEnum.Month:
                        return Booking.Price.MonthPrice * ((TimeSpan.Days + 1) / 30);
                }
                return 0;
            }
        }

        public PriceItem Set(PriceItemKindEnum kind, TimeSpan timeSpan)
        {
            Kind = kind;
            TimeSpan = timeSpan;
            return this;
        }
    }
}
