using System;

namespace uit.hotel.Queries.Helper
{
    public static class DateTimeHelper
    {
        public static bool IsTwoDateRangesOverlap(DateTimeOffset aStart, DateTimeOffset aEnd, DateTimeOffset bStart,
                                                  DateTimeOffset bEnd)
            => aStart < bEnd && bStart < aEnd;

        public static DateTimeOffset Round(this DateTimeOffset dateTime)
        {
            var updated = dateTime.AddMinutes(15);
            var minute = (int)(dateTime.Minute / 30) * 30;

            return new DateTimeOffset(
                updated.Year,
                updated.Month,
                updated.Day,
                updated.Hour,
                minute,
                0,
                TimeSpan.Zero
            );
        }

        public static float FloatHour(this DateTimeOffset dateTime)
        {
            dateTime = dateTime.Round();
            return dateTime.Hour + (float)dateTime.Minute / 60;
        }

        public static DateTimeOffset AtHour(this DateTimeOffset dateTime, int hour)
        {
            return new DateTimeOffset(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hour,
                0,
                0,
                TimeSpan.Zero
            );
        }

        public static TimeSpan Round(this TimeSpan dateTime)
        {
            var updated = dateTime.Add(new TimeSpan(0, 15, 0));
            var minutes = (int)(dateTime.Minutes / 30) * 30;

            return new TimeSpan(
                updated.Days,
                updated.Hours,
                minutes,
                0
            );
        }

        public static double FloatHour(this TimeSpan timeSpan)
            => timeSpan.Round().TotalMinutes / 60;
    }
}
