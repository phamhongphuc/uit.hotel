using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class PriceDataAccess : RealmDatabase
    {
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<Price> Add(Price price)
        {
            await Database.WriteAsync(realm =>
            {
                price.Id = NextId;
                price.CreateDate = DateTimeOffset.Now;
                price = realm.Add(price);
            });
            return price;
        }

        public static Price Add(Realm realm, Price price)
        {
            price.Id = NextId;
            price.CreateDate = DateTimeOffset.MinValue;
            return realm.Add(price);
        }

        public static async void Delete(Price priceInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(priceInDatabase));
        }

        public static async Task<Price> Update(Price priceInDatabase, Price price)
        {
            await Database.WriteAsync(realm =>
            {
                priceInDatabase.HourPrice = price.HourPrice;
                priceInDatabase.DayPrice = price.DayPrice;
                priceInDatabase.NightPrice = price.NightPrice;
                priceInDatabase.WeekPrice = price.WeekPrice;
                priceInDatabase.MonthPrice = price.MonthPrice;
                priceInDatabase.LateCheckOutFee = price.LateCheckOutFee;
                priceInDatabase.EarlyCheckInFee = price.EarlyCheckInFee;
                priceInDatabase.EffectiveStartDate = price.EffectiveStartDate;
                priceInDatabase.CreateDate = DateTimeOffset.Now;
                priceInDatabase.Employee = price.Employee;
                priceInDatabase.RoomKind = price.RoomKind;
            });
            return priceInDatabase;
        }

        public static Price Get(int priceId) => Database.Find<Price>(priceId);

        public static IEnumerable<Price> Get() => Database.All<Price>();
    }
}
