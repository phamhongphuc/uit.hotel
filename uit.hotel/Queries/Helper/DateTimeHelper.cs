using System;
using uit.hotel.Queries.Authentication;

namespace uit.hotel.Queries.Helper
{
    public static class DateTimeHelper
    {
        public static bool IsOverlap(DateTimeOffset aStart, DateTimeOffset aEnd,
                                                  DateTimeOffset bStart, DateTimeOffset bEnd)
            => aStart < bEnd && bStart < aEnd;

        public static DateTimeOffset Round(this DateTimeOffset dateTime)
        {
            var updated = dateTime.AddMinutes(15);
            var minute = (int)(updated.Minute / 30) * 30;

            return new DateTimeOffset(
                updated.Year,
                updated.Month,
                updated.Day,
                updated.Hour,
                minute,
                0,
                dateTime.Offset
            );
        }

        public static double FloatHour(this DateTimeOffset dateTime)
            => dateTime.UtcDateTime.Add(Constant.TimeZone).TimeOfDay.TotalHours;

        public static DateTimeOffset AtHour(this DateTimeOffset dateTime, int hour)
        {
            dateTime = dateTime.ToOffset(Constant.TimeZone);
            return new DateTimeOffset(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hour,
                0,
                0,
                dateTime.Offset
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

        public static float FloatHour(this TimeSpan timeSpan)
            => (float)timeSpan.Round().TotalMinutes / 60;

        public static long MultiplyByHourPrice(this TimeSpan timeSpan, long unitPrice)
            => (long)(timeSpan.FloatHour() * unitPrice);

        public static string ToAlphabet(this DateTimeOffset time)
        {
            var span = time - new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var seconds = (long)span.TotalSeconds;
            return seconds.ToAlphabet();
        }

        public static string Format(this DateTimeOffset time)
            => time.ToOffset(Constant.TimeZone).ToString("HH:mm dd/MM/yyyy ");
    }
}
