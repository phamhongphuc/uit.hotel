using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class VolatilityRateBusiness
    {
        public static Task<VolatilityRate> Add(Employee employee, VolatilityRate volatilityRate)
        {
            volatilityRate.Employee = employee;
            volatilityRate.RoomKind = volatilityRate.RoomKind.GetManaged();
            if (!volatilityRate.RoomKind.IsActive)
                throw new Exception("Loại phòng " + volatilityRate.RoomKind.Name + " đã ngưng hoại động");

            return VolatilityRateDataAccess.Add(volatilityRate);
        }

        public static VolatilityRate Get(int volatilityRateId) => VolatilityRateDataAccess.Get(volatilityRateId);
        public static IEnumerable<VolatilityRate> Get() => VolatilityRateDataAccess.Get();
    }
}
