using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class ServiceDataAccess : RealmDatabase
    {
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<Service> Add(Service service)
        {
            await Database.WriteAsync(realm =>
            {
                service.Id = NextId;
                service.IsActive = true;
                service = realm.Add(service);
            });
            return service;
        }

        public static async Task<Service> Update(Service serviceInDatabase, Service service)
        {
            await Database.WriteAsync(realm =>
            {
                serviceInDatabase.Name = service.Name;
                serviceInDatabase.UnitPrice = service.UnitPrice;
                serviceInDatabase.Unit = service.Unit;
            });
            return serviceInDatabase;
        }

        public static async void SetIsActive(Service service, bool isActive)
        {
            await Database.WriteAsync(realm => service.IsActive = isActive);
        }

        public static async void Delete(Service serviceInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(serviceInDatabase));
        }

        public static Service Get(int serviceId) => Database.Find<Service>(serviceId);

        public static IEnumerable<Service> Get() => Database.All<Service>();
    }
}
