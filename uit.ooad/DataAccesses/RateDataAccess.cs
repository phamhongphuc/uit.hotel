using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class RateDataAccess : RealmDatabase
    {
        public static async Task<Rate> Add(Rate rate)
        {
            await Database.WriteAsync(realm =>
            {
                rate.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                rate = realm.Add(rate);
            });
            return rate;
        }

        public static Rate Get(int rateId) => Database.Find<Rate>(rateId);

        public static IEnumerable<Rate> Get() => Database.All<Rate>();
    }
}
