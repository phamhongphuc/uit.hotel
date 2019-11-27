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

        [Backlink(nameof(PriceVolatilityItem.Booking))]
        private IQueryable<PriceVolatilityItem> PriceVolatilityItemsInDatabase { get; }
        [Ignored]
        private IList<PriceVolatilityItem> PriceVolatilityItemsInObject { get; set; }
        [Ignored]
        public IEnumerable<PriceVolatilityItem> PriceVolatilityItems => IsManaged ? PriceVolatilityItemsInDatabase.ToList() : PriceVolatilityItemsInObject;

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
        [Ignored]
        private IList<PriceVolatility> PriceVolatilities { get; set; }

        public void CalculatePrice()
        {
            if (!Room.IsManaged) Room = Room.GetManaged();

            BaseNightCheckInTime = (RealCheckInTime != DateTimeOffset.MinValue ? RealCheckInTime : BookCheckInTime).Round();
            BaseDayCheckInTime = DateTimeOffset.MinValue;
            BaseDayCheckOutTime = (RealCheckOutTime != DateTimeOffset.MinValue ? RealCheckOutTime : BookCheckOutTime).Round();

            Price = Room.RoomKind.GetPrice(BaseNightCheckInTime);

            InitializeData();
            CalculateCaseByCase();
            SaveResult();
        }

        private void InitializeData()
        {
            PriceItemBusiness.Delete(PriceItemsInDatabase);
            PriceItemsInObject = new List<PriceItem>();
            PriceVolatilityItemBusiness.Delete(PriceVolatilityItemsInDatabase);
            PriceVolatilityItemsInObject = new List<PriceVolatilityItem>();

            PriceVolatilities = Room.RoomKind.PriceVolatilities.ToList();
        }

        private void CalculateCaseByCase()
        {
            var isCalculated = CalculateHour();
            if (isCalculated) return;

            CalculateCheckInTime();
            CalculateCheckOutTime();

            CalculateFee();
            CalculateNight();
            CalculateDayWeekMonth();

            CalculateSumary();
        }

        private bool CalculateHour()
        {
            if (TimeSpan.FloatHour() > BookingBusiness._HourTimeSpan) return false;
            AddPriceVolatilityItems(PriceVolatilityItemKindEnum.Hour, BaseNightCheckInTime, TimeSpan);
            AddPriceItem(PriceItemKindEnum.Hour, TimeSpan);
            return true;
        }

        private void CalculateCheckInTime()
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

        private void CalculateCheckOutTime()
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
                AddPriceVolatilityItems(PriceVolatilityItemKindEnum.Night, BaseNightCheckInTime);
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

            iterateTime = beginDay;
            while (iterateTime < endDay)
            {
                AddPriceVolatilityItems(PriceVolatilityItemKindEnum.Night, BaseNightCheckInTime);
                iterateTime = iterateTime.AddDays(1);
            }
        }

        private void CalculateSumary()
        {
            TotalPrice =
                PriceItemsInObject.Aggregate<PriceItem, long>(0, (sum, x) => sum + x.Value) +
                PriceVolatilityItemsInObject.Aggregate<PriceVolatilityItem, long>(0, (sum, x) => sum + x.Value);
        }

        private void SaveResult()
        {
            PriceVolatilities.Clear();

            if (!IsManaged) return;
            PriceItemBusiness.Add(PriceItemsInObject);
            PriceVolatilityItemBusiness.Add(PriceVolatilityItemsInObject);

            PriceItemsInObject.Clear();
            PriceVolatilityItemsInObject.Clear();
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

        private void AddPriceVolatilityItems(PriceVolatilityItemKindEnum kind, DateTimeOffset date, TimeSpan timeSpan = new TimeSpan())
        {
            var priceVolatilities = PriceVolatilities.InDate(BaseNightCheckInTime);
            foreach (var priceVolatility in priceVolatilities)
            {
                var priceItem = new PriceVolatilityItem()
                {
                    Booking = this,
                    Kind = kind,
                    Date = date,
                    TimeSpan = timeSpan,
                    PriceVolatility = priceVolatility
                };
                PriceVolatilityItemsInObject.Add(priceItem);
            }
        }
    }
}
