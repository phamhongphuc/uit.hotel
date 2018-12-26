using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class HouseKeepingDataAccess : RealmDatabase
    {
        public static async Task<HouseKeeping> Add(HouseKeeping houseKeeping)
        {
            await Database.WriteAsync(realm =>
            {
                houseKeeping.Id = NextId;
                houseKeeping = realm.Add(houseKeeping);
            });
            return houseKeeping;
        }

        public static HouseKeeping Add(Realm realm, HouseKeeping houseKeeping)
        {
            houseKeeping.Id = NextId;
            return realm.Add(houseKeeping);
        }

        public static HouseKeeping Get(int houseKeepingId) => Database.Find<HouseKeeping>(houseKeepingId);

        public static IEnumerable<HouseKeeping> Get() => Database.All<HouseKeeping>();

        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        internal static async Task<HouseKeeping> AssignCleaningServiceAsync(Employee employee, HouseKeeping houseKeepingInDatabase)
        {
            await Database.WriteAsync(realm =>
            {
                houseKeepingInDatabase.Employee = employee;
                houseKeepingInDatabase.Status = (int)HouseKeeping.StatusEnum.Cleaning;
            });
            return houseKeepingInDatabase;
        }
    }
}
