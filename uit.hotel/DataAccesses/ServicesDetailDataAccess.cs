using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class ServicesDetailDataAccess : RealmDatabase
    {
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<ServicesDetail> Add(ServicesDetail servicesDetail)
        {
            await Database.WriteAsync(realm =>
            {
                servicesDetail.Id = NextId;
                servicesDetail.Time = DateTimeOffset.Now;
                servicesDetail = realm.Add(servicesDetail);
            });
            return servicesDetail;
        }

        public static ServicesDetail Add(Realm realm, ServicesDetail servicesDetail)
        {
            servicesDetail.Id = NextId;
            servicesDetail.Time = DateTimeOffset.Now;
            return realm.Add(servicesDetail);
        }

        public static async Task<ServicesDetail> Update(ServicesDetail servicesDetailInDatabase,
                                                        ServicesDetail servicesDetail)
        {
            await Database.WriteAsync(realm =>
            {
                servicesDetailInDatabase.Time = DateTimeOffset.Now;
                servicesDetailInDatabase.Number = servicesDetail.Number;
                servicesDetailInDatabase.Service = servicesDetail.Service;
            });
            return servicesDetailInDatabase;
        }

        public static async void Delete(ServicesDetail servicesDetailInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(servicesDetailInDatabase));
        }

        public static ServicesDetail Get(int servicesDetailId) => Database.Find<ServicesDetail>(servicesDetailId);

        public static IEnumerable<ServicesDetail> Get() => Database.All<ServicesDetail>();
    }
}
