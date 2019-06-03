using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class ServiceBusiness
    {
        public static Task<Service> Add(Service service)
        {
            CheckUniqueName(service);
            return ServiceDataAccess.Add(service);
        }

        public static Task<Service> Update(Service service)
        {
            var serviceInDatabase = GetAndCheckValid(service.Id);
            CheckUniqueName(service);

            return ServiceDataAccess.Update(serviceInDatabase, service);
        }

        public static void Delete(int serviceId)
        {
            var serviceInDatabase = GetAndCheckValid(serviceId);
            ServiceDataAccess.Delete(serviceInDatabase);
        }

        public static void SetIsActive(int serviceId, bool isActive)
        {
            var serviceInDatabase = Get(serviceId);
            if (serviceInDatabase == null)
                throw new Exception("Mã dịch vụ không hợp lệ!");

            ServiceDataAccess.SetIsActive(serviceInDatabase, isActive);
        }

        private static void CheckUniqueName(Service service)
        {
            var numberOfServices = Get().Where(s => s.Name == service.Name).Count();
            if (numberOfServices == 1)
                throw new Exception("Dịch vụ " + service.Name + " đã được tạo.");
            else if (numberOfServices > 1)
                throw new Exception("Cơ sở dữ liệu lỗi!");
        }

        private static Service GetAndCheckValid(int serviceId)
        {
            var serviceInDatabase = Get(serviceId);
            if (serviceInDatabase == null)
                throw new Exception("Mã dịch vụ không hợp lệ!");

            if (!serviceInDatabase.IsActive)
            {
                throw new Exception("Dịch vụ " + serviceInDatabase.Id +
                                    " đã ngừng cung cấp. Không thể cập nhật/xóa!");
            }

            if (serviceInDatabase.ServicesDetails.Count() > 0)
                throw new Exception("Dịch vụ này đã được sử dụng. Không thể cập nhật/xóa!");
            return serviceInDatabase;
        }

        public static Service Get(int serviceId) => ServiceDataAccess.Get(serviceId);
        public static IEnumerable<Service> Get() => ServiceDataAccess.Get();
    }
}
