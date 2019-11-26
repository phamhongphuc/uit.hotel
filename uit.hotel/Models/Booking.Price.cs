using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Businesses;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Models
{
    public partial class Booking : RealmObject
    {
        [Backlink(nameof(PriceItem.Booking))]
        private IQueryable<PriceItem> PriceItemsInDatabase { get; }
        [Ignored]
        private IList<PriceItem> PriceItemsInObject { get; set; }
        [Ignored]
        public IEnumerable<PriceItem> PriceItems => IsManaged ? PriceItemsInDatabase.ToList() : PriceItemsInObject;

        //? Calculated fields
        public DateTimeOffset BaseNightCheckInTime { get; private set; }
        public DateTimeOffset BaseDayCheckInTime { get; private set; }
        public DateTimeOffset BaseDayCheckOutTime { get; private set; }

        public long TotalPrice { get; set; }
        public long EarlyCheckInFee { get; set; }
        public long LateCheckOutFee { get; set; }
        public Price Price { get; set; }

        //? Temporary fields
        [Ignored]
        private TimeSpan TimeSpan => BaseDayCheckOutTime - BaseNightCheckInTime;

        public void CalculatePrice()
        {
            if (!Room.IsManaged) Room = Room.GetManaged();

            BaseNightCheckInTime = (RealCheckInTime != DateTimeOffset.MinValue ? RealCheckInTime : BookCheckInTime).Round();
            BaseDayCheckInTime = DateTimeOffset.MinValue;
            BaseDayCheckOutTime = (RealCheckOutTime != DateTimeOffset.MinValue ? RealCheckOutTime : BookCheckOutTime).Round();

            Price = Room.RoomKind.GetPrice(BaseNightCheckInTime);

            CleanItems();
            CalculateCaseByCase();
            SaveResult();
        }

        private void CleanItems()
        {
            PriceItemBusiness.Delete(PriceItemsInDatabase);
            PriceItemsInObject = new List<PriceItem>();
        }

        private void CalculateCaseByCase()
        {
            var isCalculated = CalculateHour();
            if (isCalculated) return;

            CalculateCheckIn();
            CalculateCheckOut();

            CalculateFee();
            CalculateNight();
            CalculateDayWeekMonth();
            CalculateSumary();
        }

        private bool CalculateHour()
        {
            if (TimeSpan.FloatHour() > BookingBusiness._HourTimeSpan) return false;
            AddPriceItem(PriceItemKindEnum.Hour, TimeSpan);
            return true;
        }

        private void CalculateCheckIn()
        {
            var checkInHour = BaseNightCheckInTime.FloatHour();

            if (checkInHour <= BookingBusiness._MaxCheckInNightTime)
                BaseNightCheckInTime = BaseNightCheckInTime.AtHour(BookingBusiness._CheckInNightTime).AddDays(-1);
            else if (checkInHour <= BookingBusiness._CheckInDayTime)
                BaseNightCheckInTime = BaseNightCheckInTime.AtHour(BookingBusiness._CheckInDayTime);
            else if (checkInHour <= BookingBusiness._CheckInNightTime - BookingBusiness._ToleranceTimeSpan)
                BaseNightCheckInTime.AtHour(BookingBusiness._CheckInDayTime);
            else if (checkInHour <= BookingBusiness._CheckInNightTime)
                BaseNightCheckInTime = BaseNightCheckInTime.AtHour(BookingBusiness._CheckInNightTime);
            else
                BaseNightCheckInTime = BaseNightCheckInTime.AtHour(BookingBusiness._CheckInNightTime);
        }

        private void CalculateCheckOut()
        {
            var checkOutTime = BaseDayCheckOutTime.FloatHour();

            if (checkOutTime <= BookingBusiness._CheckOutNightTime)
                BaseDayCheckOutTime = BaseDayCheckOutTime.AtHour(BookingBusiness._CheckOutNightTime);
            else if (checkOutTime <= BookingBusiness._CheckInDayTime + BookingBusiness._ToleranceTimeSpan)
                BaseDayCheckOutTime = BaseDayCheckOutTime.AtHour(BookingBusiness._CheckInNightTime);
            else
                BaseDayCheckOutTime = BaseDayCheckOutTime.AtHour(BookingBusiness._CheckOutDayTime).AddDays(1);
        }

        private void CalculateFee()
        {
            EarlyCheckInFee = (long)(Price.EarlyCheckInFee * (BookingBusiness._CheckInNightTime - BaseNightCheckInTime.FloatHour()));
            LateCheckOutFee = (long)(Price.LateCheckOutFee * (BaseDayCheckOutTime.FloatHour() - BookingBusiness._CheckOutNightTime));
        }

        private void CalculateNight()
        {
            if (BaseNightCheckInTime.FloatHour() == BookingBusiness._CheckInNightTime)
            {
                AddPriceItem(PriceItemKindEnum.Night);
                BaseDayCheckInTime = BaseNightCheckInTime.AtHour(BookingBusiness._CheckInDayTime).AddDays(1);
            }
            else
            {
                BaseDayCheckInTime = BaseNightCheckInTime;
            }
        }

        private void CalculateDayWeekMonth()
        {
            var beginDay = BaseDayCheckInTime.AtHour(0);
            var endDay = BaseDayCheckOutTime.AtHour(0);

            var iterateTime = beginDay;
            while (iterateTime < endDay)
            {
                var remain = (BaseDayCheckOutTime - iterateTime).Days;
                if (remain >= 30 && Price.MonthPrice != 0)
                {
                    var days = remain / 30 * 30;
                    AddPriceItem(PriceItemKindEnum.Month, new TimeSpan(days, 0, 0, 0));
                    iterateTime = iterateTime.AddDays(days);
                }
                else if (remain >= 7 && Price.WeekPrice != 0)
                {
                    var days = remain / 7 * 7;
                    AddPriceItem(PriceItemKindEnum.Week, new TimeSpan(days, 0, 0, 0));
                    iterateTime = iterateTime.AddDays(days);
                }
                else
                {
                    AddPriceItem(PriceItemKindEnum.Day, new TimeSpan(remain, 0, 0, 0));
                    iterateTime = iterateTime.AddDays(remain + 1);
                }
            }
        }

        private void CalculateSumary()
        {
            TotalPrice = PriceItems.Aggregate<PriceItem, long>(0, (sum, priceItem) => sum + priceItem.Value);
        }

        private void SaveResult()
        {
            if (!IsManaged) return;
            PriceItemBusiness.Add(PriceItems);
        }

        // Helper Method
        private void AddPriceItem(PriceItemKindEnum kind, TimeSpan timeSpan = new TimeSpan())
        {
            var priceItem = new PriceItem()
            {
                Booking = this,
                Kind = kind,
                TimeSpan = timeSpan
            };
            PriceItemsInObject.Add(priceItem);
        }
    }
}
