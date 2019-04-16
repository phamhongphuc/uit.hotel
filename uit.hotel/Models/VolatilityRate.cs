using System;
using Realms;

namespace uit.hotel.Models
{
    public class VolatilityRate : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public long DayRate { get; set; }
        public long NightRate { get; set; }
        public long WeekRate { get; set; }
        public long MonthRate { get; set; }
        public long LateCheckOutFee { get; set; }
        public long EarlyCheckInFee { get; set; }
        public DateTimeOffset EffectiveStartDate { get; set; }
        public DateTimeOffset EffectiveEndDate { get; set; }
        public bool EffectiveOnMonday { get; set; }
        public bool EffectiveOnTuesday { get; set; }
        public bool EffectiveOnWednesday { get; set; }
        public bool EffectiveOnThursday { get; set; }
        public bool EffectiveOnFriday { get; set; }
        public bool EffectiveOnSaturday { get; set; }
        public bool EffectiveOnSunday { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public Employee Employee { get; set; }
        public RoomKind RoomKind { get; set; }
    }
}
