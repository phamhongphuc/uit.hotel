using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class ServiceDataAccess : RealmDatabase
    {
        public static async Task<Service> Add(Service service)
        {
            await Database.WriteAsync(realm => service = realm.Add(service));
            return service;
        }
        public static async Task<Service> Update(Service service)
        {
            await Database.WriteAsync(realm => service = realm.Add(service, update: true));
            return service;
        }

        public static Service Get(int serviceId) => Database.Find<Service>(serviceId);

        public static IEnumerable<Service> Get() => Database.All<Service>();
    }
}
