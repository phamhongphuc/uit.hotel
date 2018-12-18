using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class ServicesDetailDataAccess : RealmDatabase
    {
        public static async Task<ServicesDetail> Add(ServicesDetail servicesDetail)
        {
            await Database.WriteAsync(realm =>
            {
                servicesDetail.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                servicesDetail = realm.Add(servicesDetail);
            });
            return servicesDetail;
        }

        public static ServicesDetail Get(int servicesDetailId) => Database.Find<ServicesDetail>(servicesDetailId);

        public static IEnumerable<ServicesDetail> Get() => Database.All<ServicesDetail>();
    }
}
