using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class VolatilityPriceDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<VolatilityPrice> Add(VolatilityPrice volatilityPrice)
        {
            await Database.WriteAsync(realm =>
            {
                volatilityPrice.Id = NextId;
                volatilityPrice.CreateDate = DateTimeOffset.Now;
                volatilityPrice = realm.Add(volatilityPrice);
            });
            return volatilityPrice;
        }

        public static async Task<VolatilityPrice> Update(VolatilityPrice volatilityPriceInDatabase,
                                                        VolatilityPrice volatilityPrice)
        {
            await Database.WriteAsync(realm =>
            {
                volatilityPriceInDatabase.HourPrice = volatilityPrice.HourPrice;
                volatilityPriceInDatabase.DayPrice = volatilityPrice.DayPrice;
                volatilityPriceInDatabase.NightPrice = volatilityPrice.NightPrice;
                volatilityPriceInDatabase.EffectiveStartDate = volatilityPrice.EffectiveStartDate;
                volatilityPriceInDatabase.EffectiveEndDate = volatilityPrice.EffectiveEndDate;
                volatilityPriceInDatabase.EffectiveOnMonday = volatilityPrice.EffectiveOnMonday;
                volatilityPriceInDatabase.EffectiveOnTuesday = volatilityPrice.EffectiveOnTuesday;
                volatilityPriceInDatabase.EffectiveOnWednesday = volatilityPrice.EffectiveOnWednesday;
                volatilityPriceInDatabase.EffectiveOnThursday = volatilityPrice.EffectiveOnThursday;
                volatilityPriceInDatabase.EffectiveOnFriday = volatilityPrice.EffectiveOnFriday;
                volatilityPriceInDatabase.EffectiveOnSaturday = volatilityPrice.EffectiveOnSaturday;
                volatilityPriceInDatabase.EffectiveOnSunday = volatilityPrice.EffectiveOnSunday;
                volatilityPriceInDatabase.CreateDate = DateTimeOffset.Now;
                volatilityPriceInDatabase.Employee = volatilityPrice.Employee;
                volatilityPriceInDatabase.RoomKind = volatilityPrice.RoomKind;
            });
            return volatilityPriceInDatabase;
        }

        public static async void Delete(VolatilityPrice volatilityPriceInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(volatilityPriceInDatabase));
        }

        public static VolatilityPrice Get(int volatilityPriceId) => Database.Find<VolatilityPrice>(volatilityPriceId);
        public static IEnumerable<VolatilityPrice> Get() => Database.All<VolatilityPrice>();
    }
}
