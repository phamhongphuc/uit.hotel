using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class RateDataAccess : RealmDatabase
    {
        public static async Task<Rate> Add(Rate rate)
        {
            await Database.WriteAsync(realm => rate = realm.Add(rate));
            return rate;
        }

        public static Rate Get(int rateId) => Database.Find<Rate>(rateId);

        public static IEnumerable<Rate> Get() => Database.All<Rate>();
    }
}
