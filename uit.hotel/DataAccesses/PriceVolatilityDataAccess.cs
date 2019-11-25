using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class PriceVolatilityDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<PriceVolatility> Add(PriceVolatility priceVolatility)
        {
            await Database.WriteAsync(realm =>
            {
                priceVolatility.Id = NextId;
                priceVolatility.CreateDate = DateTimeOffset.Now;
                priceVolatility = realm.Add(priceVolatility);
            });
            return priceVolatility;
        }

        public static async Task<PriceVolatility> Update(PriceVolatility priceVolatilityInDatabase,
                                                        PriceVolatility priceVolatility)
        {
            await Database.WriteAsync(realm =>
            {
                priceVolatilityInDatabase.HourPrice = priceVolatility.HourPrice;
                priceVolatilityInDatabase.DayPrice = priceVolatility.DayPrice;
                priceVolatilityInDatabase.NightPrice = priceVolatility.NightPrice;
                priceVolatilityInDatabase.EffectiveStartDate = priceVolatility.EffectiveStartDate;
                priceVolatilityInDatabase.EffectiveEndDate = priceVolatility.EffectiveEndDate;
                priceVolatilityInDatabase.EffectiveOnMonday = priceVolatility.EffectiveOnMonday;
                priceVolatilityInDatabase.EffectiveOnTuesday = priceVolatility.EffectiveOnTuesday;
                priceVolatilityInDatabase.EffectiveOnWednesday = priceVolatility.EffectiveOnWednesday;
                priceVolatilityInDatabase.EffectiveOnThursday = priceVolatility.EffectiveOnThursday;
                priceVolatilityInDatabase.EffectiveOnFriday = priceVolatility.EffectiveOnFriday;
                priceVolatilityInDatabase.EffectiveOnSaturday = priceVolatility.EffectiveOnSaturday;
                priceVolatilityInDatabase.EffectiveOnSunday = priceVolatility.EffectiveOnSunday;
                priceVolatilityInDatabase.CreateDate = DateTimeOffset.Now;
                priceVolatilityInDatabase.Employee = priceVolatility.Employee;
                priceVolatilityInDatabase.RoomKind = priceVolatility.RoomKind;
            });
            return priceVolatilityInDatabase;
        }

        public static async void Delete(PriceVolatility priceVolatilityInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(priceVolatilityInDatabase));
        }

        public static PriceVolatility Get(int priceVolatilityId) => Database.Find<PriceVolatility>(priceVolatilityId);
        public static IEnumerable<PriceVolatility> Get() => Database.All<PriceVolatility>();
    }
}
