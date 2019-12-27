using System;
using Microsoft.Extensions.Configuration;
using uit.hotel.Models;

namespace uit.hotel.Queries.Helper
{
    public static class Constant
    {
        private static IConfiguration Configuration;
        public static string AdminName = "admin";
        public static TimeSpan TimeZone = TimeZoneInfo.Local.BaseUtcOffset;
        public static string MomoSecretKey;
        public static string MomoAccessKey;
        public static string MomoPartnerCode;
        public static string MomoNotifyUrl;

        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;

            MomoSecretKey = Environment.GetEnvironmentVariable("MOMO_SECRET_KEY");
            MomoAccessKey = Environment.GetEnvironmentVariable("MOMO_ACCESS_KEY");
            MomoPartnerCode = Environment.GetEnvironmentVariable("MOMO_PARTNER_CODE");
            MomoNotifyUrl = Environment.GetEnvironmentVariable("MOMO_NOTIFY_URL");

            if (MomoSecretKey == null || MomoAccessKey == null || MomoPartnerCode == null)
            {
                MomoSecretKey = Configuration["MOMO:SECRET_KEY"];
                MomoAccessKey = Configuration["MOMO:ACCESS_KEY"];
                MomoPartnerCode = Configuration["MOMO:PARTNER_CODE"];
                MomoNotifyUrl = Configuration["MOMO:NOTIFY_URL"];
            }
        }

        static Constant()
        {
            var timeZoneString = Environment.GetEnvironmentVariable("TIMEZONE");
            if (timeZoneString != null && Int32.TryParse(timeZoneString, out int baseUtcOffset))
                TimeZone = new TimeSpan(baseUtcOffset, 0, 0);
        }
    }
}
