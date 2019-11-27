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
        public DateTimeOffset BaseCheckInTime { get; private set; }
        public DateTimeOffset BaseDayCheckInTime { get; private set; }
        public DateTimeOffset BaseCheckOutTime { get; private set; }

        public long TotalPrice { get; set; }
        public long EarlyCheckInFee { get; set; }
        public long LateCheckOutFee { get; set; }
        public Price Price { get; set; }

        //? Temporary fields
        [Ignored]
        private TimeSpan TimeSpan => BaseCheckOutTime - BaseCheckInTime;

        public void CalculatePrice()
        {
            if (!Room.IsManaged) Room = Room.GetManaged();

            BaseCheckInTime = (RealCheckInTime != DateTimeOffset.MinValue ? RealCheckInTime : BookCheckInTime).Round();
            BaseCheckOutTime = (RealCheckOutTime != DateTimeOffset.MinValue ? RealCheckOutTime : BookCheckOutTime).Round();

            Price = Room.RoomKind.GetPrice(BaseCheckInTime);

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
            var checkInHour = BaseCheckInTime.FloatHour();

            if (checkInHour <= BookingBusiness._MaxCheckInNightTime)
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInNightTime).AddDays(-1);
            else if (checkInHour <= BookingBusiness._CheckInDayTime)
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInDayTime);
            else if (checkInHour <= BookingBusiness._CheckInNightTime - BookingBusiness._ToleranceTimeSpan)
                BaseCheckInTime.AtHour(BookingBusiness._CheckInDayTime);
            else if (checkInHour <= BookingBusiness._CheckInNightTime)
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInNightTime);
            else
                BaseCheckInTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInNightTime);
        }

        private void CalculateCheckOut()
        {
            var checkOutTime = BaseCheckOutTime.FloatHour();

            if (checkOutTime <= BookingBusiness._CheckOutNightTime)
                BaseCheckOutTime = BaseCheckOutTime.AtHour(BookingBusiness._CheckOutNightTime);
            else if (checkOutTime <= BookingBusiness._CheckInDayTime + BookingBusiness._ToleranceTimeSpan)
                BaseCheckOutTime = BaseCheckOutTime.AtHour(BookingBusiness._CheckInNightTime);
            else
                BaseCheckOutTime = BaseCheckOutTime.AtHour(BookingBusiness._CheckOutDayTime).AddDays(1);
        }

        private void CalculateFee()
        {
            EarlyCheckInFee = (long)(Price.EarlyCheckInFee * (BookingBusiness._CheckInNightTime - BaseCheckInTime.FloatHour()));
            LateCheckOutFee = (long)(Price.LateCheckOutFee * (BaseCheckOutTime.FloatHour() - BookingBusiness._CheckOutNightTime));
        }

        private void CalculateNight()
        {
            if (BaseCheckInTime.FloatHour() != BookingBusiness._CheckInNightTime) return;

            var nextTime = BaseCheckInTime.AtHour(BookingBusiness._CheckInDayTime).AddDays(1);
            AddPriceItem(PriceItemKindEnum.Night, nextTime - BaseCheckInTime);
            BaseCheckInTime = nextTime;
        }

        private void CalculateDayWeekMonth()
        {
            var startDay = BaseCheckInTime.AtHour(0);
            var endDay = BaseCheckOutTime.AtHour(0);

            var iterateTime = startDay;
            while (iterateTime < endDay)
            {
                var remain = (BaseCheckOutTime - iterateTime).Days;
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
