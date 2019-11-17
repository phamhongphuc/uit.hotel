using System;
using Realms;

namespace uit.hotel.Models
{
    public class Rate : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public long HourRate { get; set; }
        public long DayRate { get; set; }
        public long NightRate { get; set; }
        public long WeekRate { get; set; }
        public long MonthRate { get; set; }
        public long LateCheckOutFee { get; set; }
        public long EarlyCheckInFee { get; set; }
        [Indexed]
        public DateTimeOffset EffectiveStartDate { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public Employee Employee { get; set; }
        public RoomKind RoomKind { get; set; }
    }
}
