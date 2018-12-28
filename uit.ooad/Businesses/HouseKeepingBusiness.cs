using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class HouseKeepingBusiness
    {
        public static Task<HouseKeeping> AssignCleaningService(Employee employee, int houseKeepingId)
        {
            var houseKeepingInDatabase = Get(houseKeepingId);
            if (houseKeepingInDatabase == null)
                throw new Exception("Mã dọn phòng không tồn tại");

            if (houseKeepingInDatabase.Status != (int) HouseKeeping.StatusEnum.Pending)
                throw new Exception("Không thể nhận phòng này. Phòng đã hoặc đang được dọn.");

            return HouseKeepingDataAccess.AssignCleaningService(employee, houseKeepingInDatabase);
        }

        public static Task<HouseKeeping> ConfirmCleaned(Employee employee, int houseKeepingId)
        {
            var houseKeepingInDatabase = GetAndCheckValid(employee, houseKeepingId);

            if (houseKeepingInDatabase.Type == (int) HouseKeeping.TypeEnum.ExpectedDeparture)
                throw new Exception("Không thể sử dụng kiểu xác nhận này đối với phòng check-out.");

            return HouseKeepingDataAccess.ConfirmCleaned(houseKeepingInDatabase);
        }

        public static Task<HouseKeeping> ConfirmCleanedAndServices(Employee employee,
                                                                   List<ServicesDetail> servicesDetails,
                                                                   int houseKeepingId)
        {
            var houseKeepingInDatabase = GetAndCheckValid(employee, houseKeepingId);

            if (houseKeepingInDatabase.Type != (int) HouseKeeping.TypeEnum.ExpectedDeparture)
                throw new Exception("Chỉ được sử dụng kiểu xác nhận này đối với phòng check-out.");

            foreach (var servicesDetail in servicesDetails)
            {
                servicesDetail.Service = servicesDetail.Service.GetManaged();
                if (servicesDetail.Service == null)
                    throw new Exception("Mã dịch vụ không tồn tại");
                if (!servicesDetail.Service.IsActive)
                    throw new Exception("Dịch vụ " + servicesDetail.Service.Name + " đã ngừng cung cấp");
            }

            return HouseKeepingDataAccess.ConfirmCleanedAndServices(houseKeepingInDatabase, servicesDetails);
        }

        private static HouseKeeping GetAndCheckValid(Employee employee, int houseKeepingId)
        {
            var houseKeepingInDatabase = Get(houseKeepingId);
            if (houseKeepingInDatabase == null)
                throw new Exception("Mã dọn phòng không tồn tại");

            if (houseKeepingInDatabase.Status != (int) HouseKeeping.StatusEnum.Cleaning)
                throw new Exception("Không thể xác nhận dọn phòng.");

            if (!houseKeepingInDatabase.Employee.Equals(employee))
                throw new Exception("Nhân viên không được phép xác nhận dọn.");
            return houseKeepingInDatabase;
        }

        public static HouseKeeping Get(int houseKeepingId) => HouseKeepingDataAccess.Get(houseKeepingId);
        public static IEnumerable<HouseKeeping> Get() => HouseKeepingDataAccess.Get();
    }
}
