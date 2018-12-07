using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class VolatilityRateBusiness
    {
        public static Task<VolatilityRate> Add(VolatilityRate volatilityRate)
        {
            var volatilityRateInDatabase = VolatilityRateDataAccess.Get(volatilityRate.Id);
            if (volatilityRateInDatabase != null) return null;

            return VolatilityRateDataAccess.Add(volatilityRate);
        }

        public static VolatilityRate Get(int volatilityRateId) => VolatilityRateDataAccess.Get(volatilityRateId);
        public static IEnumerable<VolatilityRate> Get() => VolatilityRateDataAccess.Get();
    }
}
