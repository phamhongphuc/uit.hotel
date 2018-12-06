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

            return ServicesDetailDataAccess.Add(servicesDetail);
        }
        public static ServicesDetail Get(int servicesDetailId) => ServicesDetailDataAccess.Get(servicesDetailId);
        public static IEnumerable<ServicesDetail> Get() => ServicesDetailDataAccess.Get();
    }
}
