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
            houseKeeping.Booking = houseKeeping.Booking.GetManaged();
            return HouseKeepingDataAccess.Add(houseKeeping);
        }

        public static Task<HouseKeeping> AssignCleaningService(Employee employee, int houseKeepingId)
        {
            var houseKeepingInDatabase = Get(houseKeepingId);
            if (houseKeepingInDatabase == null)
                throw new Exception("Mã dọn phòng không tồn tại");

            if (houseKeepingInDatabase.Status != (int)HouseKeeping.StatusEnum.Pending)
                throw new Exception("Không thể nhận phòng này. Phòng đã hoặc đang được dọn.");

            return HouseKeepingDataAccess.AssignCleaningService(employee, houseKeepingInDatabase);
        }

        public static Task<HouseKeeping> ConfirmCleaned(Employee employee, int houseKeepingId)
        {
            var houseKeepingInDatabase = Get(houseKeepingId);
            if (houseKeepingInDatabase == null)
                throw new Exception("Mã dọn phòng không tồn tại");

            if (houseKeepingInDatabase.Status != (int)HouseKeeping.StatusEnum.Cleaning)
                throw new Exception("Không thể xác nhận dọn phòng.");

            if(!houseKeepingInDatabase.Employee.Equals(employee))
                throw new Exception("Nhân viên không được phép xác nhận dọn.");

            return HouseKeepingDataAccess.ConfirmCleaned(houseKeepingInDatabase);
        }
        public static HouseKeeping Get(int houseKeepingId) => HouseKeepingDataAccess.Get(houseKeepingId);
        public static IEnumerable<HouseKeeping> Get() => HouseKeepingDataAccess.Get();
    }
}
