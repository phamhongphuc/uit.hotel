using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class ServicesDetailBusiness
    {
        public static ServicesDetail Get(int servicesDetailId) => ServicesDetailDataAccess.Get(servicesDetailId);
        public static IEnumerable<ServicesDetail> Get() => ServicesDetailDataAccess.Get();

        public static Task<ServicesDetail> Update(ServicesDetail servicesDetail)
        {
            var servicesDetailInDatabase = Get(servicesDetail.Id);
            if (servicesDetailInDatabase == null)
                throw new Exception("Mã chi tiết dịch vụ không tồn tại");

            if (servicesDetailInDatabase.Booking.Status != (int)Booking.StatusEnum.RequestedCheckOut)
                throw new Exception("Không thể cập nhật chi tiết dịch vụ.");

            servicesDetail.Service = servicesDetail.Service.GetManaged();
            if(!servicesDetail.Service.IsActive)
                throw new Exception("Dịch vụ " +servicesDetail.Service.Name+" đã ngừng cung cấp");
                
            return ServicesDetailDataAccess.Update(servicesDetailInDatabase, servicesDetail);
        }
    }
}
