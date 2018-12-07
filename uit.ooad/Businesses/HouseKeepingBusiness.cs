using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class HouseKeepingBusiness
    {
        public static Task<HouseKeeping> Add(HouseKeeping houseKeeping)
        {
            var houseKeepingInDatabase = HouseKeepingDataAccess.Get(houseKeeping.Id);
            if (houseKeepingInDatabase != null) return null;

            houseKeeping.Employee = houseKeeping.Employee.GetManaged();
            houseKeeping.Booking = houseKeeping.Booking.GetManaged();
            return HouseKeepingDataAccess.Add(houseKeeping);
        }

        public static HouseKeeping Get(int houseKeepingId) => HouseKeepingDataAccess.Get(houseKeepingId);
        public static IEnumerable<HouseKeeping> Get() => HouseKeepingDataAccess.Get();
    }
}
