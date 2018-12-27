using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class ServicesDetailBusiness
    {
        public static ServicesDetail Get(int servicesDetailId) => ServicesDetailDataAccess.Get(servicesDetailId);
        public static IEnumerable<ServicesDetail> Get() => ServicesDetailDataAccess.Get();
    }
}
