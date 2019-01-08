using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class VolatilityRateDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<VolatilityRate> Add(VolatilityRate volatilityRate)
        {
            await Database.WriteAsync(realm =>
            {
                volatilityRate.Id = NextId;
                volatilityRate.CreateDate = DateTimeOffset.Now;
                volatilityRate = realm.Add(volatilityRate);
            });
            return volatilityRate;
        }

        public static async Task<VolatilityRate> Update(VolatilityRate volatilityRateInDatabase,
                                                        VolatilityRate volatilityRate)
        {
            await Database.WriteAsync(realm =>
            {
                volatilityRateInDatabase.DayRate = volatilityRate.DayRate;
                volatilityRateInDatabase.NightRate = volatilityRate.NightRate;
                volatilityRateInDatabase.WeekRate = volatilityRate.WeekRate;
                volatilityRateInDatabase.MonthRate = volatilityRate.MonthRate;
                volatilityRateInDatabase.LateCheckOutFee = volatilityRate.LateCheckOutFee;
                volatilityRateInDatabase.EarlyCheckInFee = volatilityRate.EarlyCheckInFee;
                volatilityRateInDatabase.EffectiveStartDate = volatilityRate.EffectiveStartDate;
                volatilityRateInDatabase.EffectiveEndDate = volatilityRate.EffectiveEndDate;
                volatilityRateInDatabase.EffectiveOnMonday = volatilityRate.EffectiveOnMonday;
                volatilityRateInDatabase.EffectiveOnTuesday = volatilityRate.EffectiveOnTuesday;
                volatilityRateInDatabase.EffectiveOnWednesday = volatilityRate.EffectiveOnWednesday;
                volatilityRateInDatabase.EffectiveOnThursday = volatilityRate.EffectiveOnThursday;
                volatilityRateInDatabase.EffectiveOnFriday = volatilityRate.EffectiveOnFriday;
                volatilityRateInDatabase.EffectiveOnSaturday = volatilityRate.EffectiveOnSaturday;
                volatilityRateInDatabase.EffectiveOnSunday = volatilityRate.EffectiveOnSunday;
                volatilityRateInDatabase.CreateDate = DateTimeOffset.Now;
                volatilityRateInDatabase.Employee = volatilityRate.Employee;
                volatilityRateInDatabase.RoomKind = volatilityRate.RoomKind;
            });
            return volatilityRateInDatabase;
        }

        public static async void Delete(VolatilityRate volatilityRateInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(volatilityRateInDatabase));
        }

        public static VolatilityRate Get(int volatilityRateId) => Database.Find<VolatilityRate>(volatilityRateId);
        public static IEnumerable<VolatilityRate> Get() => Database.All<VolatilityRate>();
    }
}
