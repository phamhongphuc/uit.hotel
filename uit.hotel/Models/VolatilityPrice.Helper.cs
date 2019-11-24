using System;
using System.Collections.Generic;

namespace uit.hotel.Models
{
    public static class VolatilityPriceHelper
    {
        public static IList<VolatilityPrice> InDate(this IList<VolatilityPrice> volatilityPrices, DateTimeOffset date)
        {
            var dayOfWeek = date.DayOfWeek;
            IList<VolatilityPrice> selecteds = new List<VolatilityPrice> { };
            foreach (var v in volatilityPrices)
            {
                if (v.EffectiveStartDate <= date && date <= v.EffectiveEndDate)
                {
                    switch (dayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            if (v.EffectiveOnMonday) selecteds.Add(v);
                            break;
                        case DayOfWeek.Tuesday:
                            if (v.EffectiveOnTuesday) selecteds.Add(v);
                            break;
                        case DayOfWeek.Wednesday:
                            if (v.EffectiveOnWednesday) selecteds.Add(v);
                            break;
                        case DayOfWeek.Thursday:
                            if (v.EffectiveOnThursday) selecteds.Add(v);
                            break;
                        case DayOfWeek.Saturday:
                            if (v.EffectiveOnSaturday) selecteds.Add(v);
                            break;
                        case DayOfWeek.Sunday:
                            if (v.EffectiveOnSunday) selecteds.Add(v);
                            break;
                    }
                }
            }
            return selecteds;
        }

        public static VolatilityPrice Sum(this IList<VolatilityPrice> volatilityPrices)
        {
            var sum = new VolatilityPrice()
            {
                HourPrice = 0,
                DayPrice = 0,
                NightPrice = 0,
            };
            foreach (var v in volatilityPrices) sum += v;
            return sum;
        }
    }
}
