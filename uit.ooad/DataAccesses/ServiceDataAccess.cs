using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class ServiceDataAccess : RealmDatabase
    {
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<Service> Add(Service service)
        {
            await Database.WriteAsync(realm =>
            {
                service.Id = NextId;

                service = realm.Add(service);
            });
            return service;
        }

        public static async Task<Service> Update(Service serviceInDatabase, Service service)
        {
            await Database.WriteAsync(realm =>
            {
                serviceInDatabase.Name = service.Name;
                serviceInDatabase.UnitRate = service.UnitRate;
                serviceInDatabase.Unit = service.Unit;
            });
            return serviceInDatabase;
        }

        public static async void SetIsActive(Service service, bool isActive)
        {
            await Database.WriteAsync(realm => service.IsActive = isActive);
        }

        public static Service Get(int serviceId) => Database.Find<Service>(serviceId);

        public static IEnumerable<Service> Get() => Database.All<Service>();
    }
}
