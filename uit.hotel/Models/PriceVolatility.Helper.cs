using System;
using System.Collections.Generic;

namespace uit.hotel.Models
{
    public static class PriceVolatilityHelper
    {
        public static IList<PriceVolatility> InDate(this IList<PriceVolatility> priceVolatilities, DateTimeOffset date)
        {
            var dayOfWeek = date.DayOfWeek;
            IList<PriceVolatility> selecteds = new List<PriceVolatility> { };
            foreach (var v in priceVolatilities)
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

        public static PriceVolatility Sum(this IList<PriceVolatility> priceVolatilities)
        {
            var sum = new PriceVolatility()
            {
                HourPrice = 0,
                DayPrice = 0,
                NightPrice = 0,
            };
            foreach (var v in priceVolatilities) sum += v;
            return sum;
        }
    }
}
