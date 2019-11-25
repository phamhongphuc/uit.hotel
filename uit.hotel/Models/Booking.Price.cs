using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using uit.hotel.Businesses;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Models
{
    public partial class Booking : RealmObject
    {
        public long TotalPrice { get; set; }

        //? Calculated fields
        public DateTimeOffset BaseCheckInTime { get; private set; }
        public DateTimeOffset BaseCheckOutTime { get; private set; }

        public Price Price { get; private set; }
        public long HourPrice { get; private set; }
        public long NightPrice { get; private set; }
        public long DayPrice { get; private set; }
        public long EarlyCheckInFee { get; private set; }
        public long LateCheckOutFee { get; private set; }

        public void UpdateAndCalculatePrice()
        {
            Room = Room.GetManaged();
            CalculatePrice();
        }

        public void CalculatePrice()
        {
            BaseCheckInTime = (RealCheckInTime != DateTimeOffset.MinValue ? RealCheckInTime : BookCheckInTime).Round();
            BaseCheckOutTime = (RealCheckOutTime != DateTimeOffset.MinValue ? RealCheckOutTime : BookCheckOutTime).Round();

            Price = Room.RoomKind.GetPrice(BaseCheckInTime);

            EarlyCheckInFee = 0;
            LateCheckOutFee = 0;
            HourPrice = 0;
            NightPrice = 0;
            DayPrice = 0;

            CalculateCaseByCase();

            TotalPrice = HourPrice + EarlyCheckInFee + LateCheckOutFee + NightPrice + DayPrice;
        }

        private void CalculateCaseByCase()
        {
            CalculateHour();
            if (HourPrice != 0) return;

            CalculateCheckIn();
            CalculateCheckOut();
            CalculateNight();
            CalculateDay();
        }

        private void CalculateHour()
        {
            var timeSpan = BaseCheckOutTime - BaseCheckInTime;
            if (timeSpan.FloatHour() <= BookingBusiness._HourTimeSpan)
            {
                var price = Price.HourPrice;
                HourPrice = timeSpan.MultiplyByHourPrice(price);
            }
        }

        private void CalculateCheckIn()
        {
            var checkInHour = BaseCheckInTime.FloatHour();
            if (checkInHour <= BookingBusiness._MaxCheckInNightTime)
            {
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInNightTime).AddDays(-1);
            }
            else if (checkInHour <= BookingBusiness._CheckInDayTime)
            {
                EarlyCheckInFee = (long)(Price.EarlyCheckInFee * (BookingBusiness._CheckInDayTime - checkInHour));
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInDayTime);
            }
            else if (checkInHour <= BookingBusiness._CheckInNightTime - BookingBusiness._ToleranceTimeSpan)
            {
                BaseCheckInTime.AtHour(BookingBusiness._CheckInDayTime);
            }
            else if (checkInHour <= BookingBusiness._CheckInNightTime)
            {
                EarlyCheckInFee = (long)(Price.EarlyCheckInFee * (BookingBusiness._CheckInNightTime - checkInHour));
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInNightTime);
            }
            else
            {
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInNightTime);
            }
        }

        private void CalculateCheckOut()
        {
            var checkOutTime = BaseCheckOutTime.FloatHour();
            if (checkOutTime <= BookingBusiness._CheckOutNightTime)
            {
                BaseCheckOutTime = BaseCheckOutTime.AtHour(BookingBusiness._CheckOutNightTime);
            }
            else if (checkOutTime <= BookingBusiness._CheckInDayTime + BookingBusiness._ToleranceTimeSpan)
            {
                BaseCheckOutTime = BaseCheckOutTime.AtHour(BookingBusiness._CheckInNightTime);
                LateCheckOutFee = (long)(Price.LateCheckOutFee * (checkOutTime - BookingBusiness._CheckOutNightTime));
            }
            else
            {
                BaseCheckOutTime = BaseCheckOutTime.AtHour(BookingBusiness._CheckOutDayTime).AddDays(1);
            }
        }

        private void CalculateNight()
        {
            if (BaseCheckInTime.FloatHour() == BookingBusiness._CheckInNightTime) // isNight
            {
                NightPrice = Price.NightPrice;
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInDayTime).AddDays(1);
            }
        }

        private void CalculateDay()
        {
            var iterateTime = BaseCheckInTime;
            while (iterateTime <= BaseCheckOutTime)
            {
                var remain = (BaseCheckOutTime - iterateTime).Days;
                if (remain >= 30 && Price.MonthPrice != 0)
                {
                    DayPrice += Price.MonthPrice;
                    iterateTime = iterateTime.AddDays(30);
                }
                else if (remain >= 7 && Price.WeekPrice != 0)
                {
                    DayPrice += Price.WeekPrice;
                    iterateTime = iterateTime.AddDays(7);
                }
                else
                {
                    DayPrice += Price.DayPrice;
                    iterateTime = iterateTime.AddDays(1);
                }
            }
        }
    }
}
