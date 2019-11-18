using System;
using Realms;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Models
{
    public partial class Booking : RealmObject
    {
        //? Calculated fields
        public DateTimeOffset BaseCheckInTime { get; private set; }
        public DateTimeOffset BaseCheckOutTime { get; private set; }
        public Rate Rate { get; private set; }
        public long HourPrice { get; private set; }
        public long NightPrice { get; private set; }
        public long DayPrice { get; private set; }
        public long EarlyCheckInFee { get; private set; }
        public long LateCheckOutFee { get; private set; }

        public void CalculateRate()
        {
            BaseCheckInTime = (RealCheckInTime != DateTimeOffset.MinValue ? RealCheckInTime : BookCheckInTime).Round();
            BaseCheckOutTime = (RealCheckOutTime != DateTimeOffset.MinValue ? RealCheckOutTime : BookCheckOutTime).Round();

            Rate = Room.RoomKind.GetRate(BaseCheckInTime);
            HourPrice = 0;
            EarlyCheckInFee = 0;
            LateCheckOutFee = 0;
            NightPrice = 0;
            DayPrice = 0;

            CalculateHour();
            if (HourPrice == 0)
            {
                CalculateCheckIn();
                CalculateCheckOut();
                CalculateNight();
                CalculateDay();
            }

            TotalRate = HourPrice + EarlyCheckInFee + LateCheckOutFee + NightPrice + DayPrice;
        }

        private void CalculateHour()
        {
            var timeSpan = BaseCheckOutTime - BaseCheckInTime;
            if (timeSpan.FloatHour() <= Rate.HourTimeSpan)
            {
                HourPrice = (long)(Rate.HourRate * timeSpan.FloatHour());
            }
        }

        private void CalculateCheckIn()
        {
            var checkInHour = BaseCheckInTime.FloatHour();
            if (checkInHour <= Rate.MaxCheckInNightTime)
            {
                BaseCheckInTime = BaseCheckInTime.AtHour(Rate.CheckInNightTime).AddDays(-1);
            }
            else if (checkInHour <= Rate.CheckInDayTime)
            {
                EarlyCheckInFee = (long)(Rate.EarlyCheckInFee * (Rate.CheckInDayTime - checkInHour));
                BaseCheckInTime = BaseCheckInTime.AtHour(Rate.CheckInDayTime);
            }
            else if (checkInHour <= Rate.CheckInNightTime - Rate.ToleranceTimeSpan)
            {
                BaseCheckInTime.AtHour(Rate.CheckInDayTime);
            }
            else if (checkInHour <= Rate.CheckInNightTime)
            {
                EarlyCheckInFee = (long)(Rate.EarlyCheckInFee * (Rate.CheckInNightTime - checkInHour));
                BaseCheckInTime = BaseCheckInTime.AtHour(Rate.CheckInNightTime);
            }
            else
            {
                BaseCheckInTime = BaseCheckInTime.AtHour(Rate.CheckInNightTime);
            }
        }

        private void CalculateCheckOut()
        {
            var checkOutTime = BaseCheckOutTime.FloatHour();
            if (checkOutTime <= Rate.CheckOutNightTime)
            {
                BaseCheckOutTime = BaseCheckOutTime.AtHour(Rate.CheckOutNightTime);
            }
            else if (checkOutTime <= Rate.CheckInDayTime + Rate.ToleranceTimeSpan)
            {
                BaseCheckOutTime = BaseCheckOutTime.AtHour(Rate.CheckInNightTime);
                LateCheckOutFee = (long)(Rate.LateCheckOutFee * (checkOutTime - Rate.CheckOutNightTime));
            }
            else
            {
                BaseCheckOutTime = BaseCheckOutTime.AtHour(Rate.CheckOutDayTime).AddDays(1);
            }
        }

        private void CalculateNight()
        {
            if (BaseCheckInTime.FloatHour() == Rate.CheckInNightTime) // isNight
            {
                NightPrice = Rate.NightRate;
                BaseCheckInTime = BaseCheckInTime.AtHour(Rate.CheckInDayTime).AddDays(1);
            }
        }

        private void CalculateDay()
        {
            var iterateTime = BaseCheckInTime;
            while (iterateTime <= BaseCheckOutTime)
            {
                var remain = (BaseCheckOutTime - iterateTime).Days;
                if (remain >= 30 && Rate.MonthRate != 0)
                {
                    DayPrice += Rate.MonthRate;
                    iterateTime = iterateTime.AddDays(30);
                }
                else if (remain >= 7 && Rate.WeekRate != 0)
                {
                    DayPrice += Rate.WeekRate;
                    iterateTime = iterateTime.AddDays(7);
                }
                else
                {
                    DayPrice += Rate.DayRate;
                    iterateTime = iterateTime.AddDays(1);
                }
            }
        }
    }
}
