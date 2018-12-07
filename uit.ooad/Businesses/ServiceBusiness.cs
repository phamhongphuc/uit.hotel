using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class ServiceBusiness
    {
        public static Task<Service> Add(Service service)
        {
            var serviceInDatabase = ServiceDataAccess.Get(service.Id);
            if (serviceInDatabase != null) return null;

            return ServiceDataAccess.Add(service);
        }

        public static Service Get(int serviceId) => ServiceDataAccess.Get(serviceId);
        public static IEnumerable<Service> Get() => ServiceDataAccess.Get();
    }
}
