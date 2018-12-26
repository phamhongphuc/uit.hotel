using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class HouseKeepingBusiness
    {
        public static Task<HouseKeeping> Add(HouseKeeping houseKeeping)
        {
            houseKeeping.Employee = houseKeeping.Employee.GetManaged();
            if (!houseKeeping.Employee.IsActive)
                throw new Exception("Tài khoản " + houseKeeping.Employee.Id + " đã bị vô hiệu hóa");

            houseKeeping.Booking = houseKeeping.Booking.GetManaged();
            return HouseKeepingDataAccess.Add(houseKeeping);
        }

        public static HouseKeeping Get(int houseKeepingId) => HouseKeepingDataAccess.Get(houseKeepingId);
        public static IEnumerable<HouseKeeping> Get() => HouseKeepingDataAccess.Get();

        public static Employee GetFreeEmployee()
        {
            return EmployeeBusiness.Get()
                .Where(e => e.Position.PermissionAssignHouseKeeping)
                .FirstOrDefault();
        }
    }
}
