using System;
using System.Collections.Generic;
using System.Globalization;

namespace uit.ooad.Queries.Helper
{
    public static class DateTimeHelper
    {
        public static IEnumerable<DateTimeOffset> EachDay(DateTimeOffset from, DateTimeOffset to)
        {
            for (DateTimeOffset date = from; date <= to; date = date.AddDays(1))
                yield return date;
        }

        public static bool IsTwoDateRangesOverlap(DateTimeOffset aStart, DateTimeOffset aEnd, DateTimeOffset bStart, DateTimeOffset bEnd)
            => aStart < bEnd && bStart < aEnd;

        public static DateTimeOffset GetDate(int dd, int mm, int yyyy)
        {
            return DateTimeOffset.ParseExact(
                String.Format("{0}/{1}/{2}", dd, mm, yyyy),
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture
            );
        }
    }
}
