using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class RateBusiness
    {
        public static Task<Rate> Add(Rate rate)
        {
            rate.RoomKind = rate.RoomKind.GetManaged();
            if (!rate.RoomKind.IsActive)
                throw new Exception("Loại phòng " + rate.RoomKind.Name + " đã ngưng hoại động");

            return RateDataAccess.Add(rate);
        }

        public static Rate Get(int rateId) => RateDataAccess.Get(rateId);
        public static IEnumerable<Rate> Get() => RateDataAccess.Get();
    }
}
