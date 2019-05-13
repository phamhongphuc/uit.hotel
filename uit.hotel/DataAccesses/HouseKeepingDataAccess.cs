using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class HouseKeepingDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

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

        public static async Task<HouseKeeping> AssignCleaningService(Employee employee,
                                                                     HouseKeeping houseKeepingInDatabase)
        {
            await Database.WriteAsync(realm =>
            {
                houseKeepingInDatabase.Employee = employee;
                houseKeepingInDatabase.Status = (int)HouseKeeping.StatusEnum.Cleaning;
            });
            return houseKeepingInDatabase;
        }

        public static async Task<HouseKeeping> ConfirmCleaned(HouseKeeping houseKeepingInDatabase)
        {
            await Database.WriteAsync(realm =>
            {
                houseKeepingInDatabase.Status = (int)HouseKeeping.StatusEnum.Cleaned;
            });
            return houseKeepingInDatabase;
        }

        public static async Task<HouseKeeping> ConfirmCleanedAndServices(
            HouseKeeping houseKeepingInDatabase, List<ServicesDetail> servicesDetails)
        {
            await Database.WriteAsync(realm =>
            {
                foreach (var servicesDetail in servicesDetails)
                {
                    servicesDetail.Booking = houseKeepingInDatabase.Booking;
                    ServicesDetailDataAccess.Add(realm, servicesDetail);
                }

                houseKeepingInDatabase.Status = (int)HouseKeeping.StatusEnum.Cleaned;
            });
            return houseKeepingInDatabase;
        }

        public static HouseKeeping Get(int houseKeepingId) => Database.Find<HouseKeeping>(houseKeepingId);

        public static IEnumerable<HouseKeeping> Get() => Database.All<HouseKeeping>();
    }
}
