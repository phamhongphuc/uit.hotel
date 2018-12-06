using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class ServicesDetailDataAccess : RealmDatabase
    {
        public static async Task<ServicesDetail> Add(ServicesDetail servicesDetail)
        {
            await Database.WriteAsync(realm => servicesDetail = realm.Add(servicesDetail));
            return servicesDetail;
        }

        public static ServicesDetail Get(int servicesDetailId) => Database.Find<ServicesDetail>(servicesDetailId);

        public static IEnumerable<ServicesDetail> Get() => Database.All<ServicesDetail>();
    }
}
