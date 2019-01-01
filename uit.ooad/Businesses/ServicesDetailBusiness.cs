using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class ServicesDetailBusiness
    {
        public static Task<ServicesDetail> Add(ServicesDetail servicesDetail)
        {
            servicesDetail.Booking = servicesDetail.Booking.GetManaged();
            servicesDetail.Service = servicesDetail.Service.GetManaged();
            if (!servicesDetail.Service.IsActive)
                throw new Exception("Dịch vụ " + servicesDetail.Service.Name + " đã ngừng cung cấp");

            return ServicesDetailDataAccess.Add(servicesDetail);
        }

        public static Task<ServicesDetail> Update(ServicesDetail servicesDetail)
        {
            var servicesDetailInDatabase = GetAndCheckValid(servicesDetail.Id);

            servicesDetail.Service = servicesDetail.Service.GetManaged();
            if (!servicesDetail.Service.IsActive)
                throw new Exception("Dịch vụ " + servicesDetail.Service.Name + " đã ngừng cung cấp");

            return ServicesDetailDataAccess.Update(servicesDetailInDatabase, servicesDetail);
        }

        public static void Delete(int servicesDetailId)
        {
            var servicesDetailInDatabase = GetAndCheckValid(servicesDetailId);
            ServicesDetailDataAccess.Delete(servicesDetailInDatabase);
        }

        private static ServicesDetail GetAndCheckValid(int servicesDetailId)
        {
            var servicesDetailInDatabase = Get(servicesDetailId);
            if (servicesDetailInDatabase == null)
                throw new Exception("Mã chi tiết dịch vụ không tồn tại");

            if (servicesDetailInDatabase.Booking.Status == (int) Booking.StatusEnum.CheckedOut)
                throw new Exception("Phòng đã check-out. Không thể cập nhật/xóa chi tiết dịch vụ.");
            return servicesDetailInDatabase;
        }

        public static ServicesDetail Get(int servicesDetailId) => ServicesDetailDataAccess.Get(servicesDetailId);
        public static IEnumerable<ServicesDetail> Get() => ServicesDetailDataAccess.Get();
    }
}
