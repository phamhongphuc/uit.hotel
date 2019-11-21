using System;
using System.Linq;
using Realms;

namespace uit.hotel.Models
{
    public class Price : RealmObject
    {
        public static int CheckInDayTime = 13;
        public static int CheckOutDayTime = 11;
        public static int CheckInNightTime = 21;
        public static int CheckOutNightTime = 11;
        public static int MaxCheckInNightTime = 6;
        public static int ToleranceTimeSpan = 4;
        public static int HourTimeSpan = 4;

        [PrimaryKey]
        public int Id { get; set; }
        public long HourPrice { get; set; }
        public long DayPrice { get; set; }
        public long NightPrice { get; set; }
        public long WeekPrice { get; set; }
        public long MonthPrice { get; set; }
        public long LateCheckOutFee { get; set; }
        public long EarlyCheckInFee { get; set; }
        [Indexed]
        public DateTimeOffset EffectiveStartDate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public Employee Employee { get; set; }
        public RoomKind RoomKind { get; set; }

        [Backlink(nameof(Booking.Price))]
        public IQueryable<Booking> Bookings { get; }
    }
}
