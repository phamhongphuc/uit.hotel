using System;
using System.Collections.Generic;
using System.Linq;
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
        public static Task<Service> Update(Service service)
        {
            var serviceInDatabase = ServiceDataAccess.Get(service.Id);
            if (serviceInDatabase == null)
                throw new Exception("Mã dịch vụ không hợp lệ!");
            if (serviceInDatabase.ServicesDetails.Count() > 0)
            {
                throw new Exception("Dịch vụ này đã được sử dụng, không thể cập nhật!");
            }
            return ServiceDataAccess.Update(service);
        }

        public static Service Get(int serviceId) => ServiceDataAccess.Get(serviceId);
        public static IEnumerable<Service> Get() => ServiceDataAccess.Get();
    }
}
