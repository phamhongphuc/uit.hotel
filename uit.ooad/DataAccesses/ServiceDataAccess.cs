using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class ServiceDataAccess : RealmDatabase
    {
        public static async Task<Service> Add(Service service)
        {
            await Database.WriteAsync(realm =>
            {
                service.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                service = realm.Add(service);
            });
            return service;
        }
        public static async Task<Service> Update(Service service)
        {
            await Database.WriteAsync(realm => service = realm.Add(service, update: true));
            return service;
        }
        public static async void SetIsActive(Service service, bool isActive)
        {
            await Database.WriteAsync(realm => service.IsActive = isActive);
        }
        public static Service Get(int serviceId) => Database.Find<Service>(serviceId);

        public static IEnumerable<Service> Get() => Database.All<Service>();
    }
}
