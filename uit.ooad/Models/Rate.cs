using System;
using Realms;

namespace uit.ooad.Models
{
    public class Rate : RealmObject
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
        public DateTimeOffset CreateDate { get; set; }
        public RoomType RoomType { get; set; }
    }
}
