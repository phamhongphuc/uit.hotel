using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class RoomKindDataAccess : RealmDatabase
    {
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;
        public static async Task<RoomKind> Add(RoomKind roomKind)
        {
            await Database.WriteAsync(realm =>
            {
                roomKind.Id = NextId;

                var rate = new Rate();
                rate.DayRate = 0;
                rate.NightRate = 0;
                rate.WeekRate = 0;
                rate.MonthRate = 0;
                rate.LateCheckOutFee = 0;
                rate.EarlyCheckInFee = 0;
                rate.EffectiveStartDate = DateTimeOffset.MinValue;
                rate.CreateDate = DateTimeOffset.MinValue;
                rate.RoomKind = roomKind;
                RateDataAccess.Add(realm, rate);

                roomKind = realm.Add(roomKind);
            });
            return roomKind;
        }

        public static async Task<RoomKind> Update(RoomKind roomKindInDatabase, RoomKind roomKind)
        {
            await Database.WriteAsync(realm =>
            {
                roomKindInDatabase.Name = roomKind.Name;
                roomKindInDatabase.NumberOfBeds = roomKind.NumberOfBeds;
                roomKindInDatabase.AmountOfPeople = roomKind.AmountOfPeople;
                roomKindInDatabase.PriceByDate = roomKind.PriceByDate;
            });
            return roomKindInDatabase;
        }

        internal static async void SetIsActive(RoomKind roomKind, bool isActive)
        {
            await Database.WriteAsync(realm => roomKind.IsActive = isActive);
        }

        public static RoomKind Get(int roomKindId) => Database.Find<RoomKind>(roomKindId);

        public static async void Delete(RoomKind roomKind)
        {
            await Database.WriteAsync(realm =>
            {
                realm.RemoveRange(roomKind.VolatilityRates);
                realm.Remove(roomKind);
            });
        }

        public static IEnumerable<RoomKind> Get() => Database.All<RoomKind>();
    }
}
