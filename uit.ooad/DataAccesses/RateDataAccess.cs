using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class RateDataAccess : RealmDatabase
    {
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;
        public static async Task<Rate> Add(Rate rate)
        {
            await Database.WriteAsync(realm =>
            {
                rate.Id = NextId;

                rate = realm.Add(rate);
            });
            return rate;
        }
        public static Rate Add(Realm realm, Rate rate)
        {
            rate.Id = NextId;
            return realm.Add(rate);
        }
        public static Rate Get(int rateId) => Database.Find<Rate>(rateId);

        public static IEnumerable<Rate> Get() => Database.All<Rate>();

        public static async void Delete(Rate rateInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(rateInDatabase));
        }

        internal static async Task<Rate> Update(Rate rateInDatabase, Rate rate)
        {
            await Database.WriteAsync(realm =>
            {
                rateInDatabase.DayRate = rate.DayRate;
                rateInDatabase.NightRate = rate.NightRate;
                rateInDatabase.WeekRate = rate.WeekRate;
                rateInDatabase.MonthRate = rate.MonthRate;
                rateInDatabase.LateCheckOutFee = rate.LateCheckOutFee;
                rateInDatabase.EarlyCheckInFee = rate.EarlyCheckInFee;
                rateInDatabase.EffectiveStartDate = rate.EffectiveStartDate;
                rateInDatabase.CreateDate = DateTimeOffset.Now;
                rateInDatabase.Employee = rate.Employee;
                rateInDatabase.RoomKind = rate.RoomKind;
            });
            return rateInDatabase;
        }
    }
}
