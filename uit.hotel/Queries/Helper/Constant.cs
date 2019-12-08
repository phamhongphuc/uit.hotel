using System;
using uit.hotel.Models;

namespace uit.hotel.Queries.Helper
{
    public static class Constant
    {
        public static string AdminName = "admin";

        public static TimeSpan TimeZone = TimeZoneInfo.Local.BaseUtcOffset;

        static Constant()
        {
            var timeZoneString = Environment.GetEnvironmentVariable("TIMEZONE");
            if (timeZoneString != null && Int32.TryParse(timeZoneString, out int baseUtcOffset))
                TimeZone = new TimeSpan(baseUtcOffset, 0, 0);
        }
    }
}
