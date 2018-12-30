using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class VolatilityRateDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;
        public static async Task<VolatilityRate> Add(VolatilityRate volatilityRate)
        {
            await Database.WriteAsync(realm =>
            {
                volatilityRate.Id = NextId;
                volatilityRate = realm.Add(volatilityRate);
            });
            return volatilityRate;
        }

        public static VolatilityRate Get(int volatilityRateId) => Database.Find<VolatilityRate>(volatilityRateId);

        public static IEnumerable<VolatilityRate> Get() => Database.All<VolatilityRate>();
    }
}
