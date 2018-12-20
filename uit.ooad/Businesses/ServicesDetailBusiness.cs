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
            servicesDetail.Service = servicesDetail.Service.GetManaged();
            if (!servicesDetail.Service.IsActive)
                throw new Exception("Dịch vụ " + servicesDetail.Service.Name + " đã ngừng cung cấp");

            servicesDetail.Booking = servicesDetail.Booking.GetManaged();
            return ServicesDetailDataAccess.Add(servicesDetail);
        }

        public static ServicesDetail Get(int servicesDetailId) => ServicesDetailDataAccess.Get(servicesDetailId);
        public static IEnumerable<ServicesDetail> Get() => ServicesDetailDataAccess.Get();
    }
}
