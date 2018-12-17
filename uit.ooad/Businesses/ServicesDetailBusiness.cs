using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class ServicesDetailBusiness
    {
        public static Task<ServicesDetail> Add(ServicesDetail servicesDetail)
        {
            var servicesDetailInDatabase = ServicesDetailDataAccess.Get(servicesDetail.Id);
            if (servicesDetailInDatabase != null) return null;

            Service service = servicesDetail.Service = servicesDetail.Service.GetManaged();
            if (!service.IsActive)
                throw new Exception("Dịch vụ được chọn có Id=" + service.Id + " đã bị vô hiệu hóa");
            servicesDetail.Booking = servicesDetail.Booking.GetManaged();
            return ServicesDetailDataAccess.Add(servicesDetail);
        }

        public static ServicesDetail Get(int servicesDetailId) => ServicesDetailDataAccess.Get(servicesDetailId);
        public static IEnumerable<ServicesDetail> Get() => ServicesDetailDataAccess.Get();
    }
}
