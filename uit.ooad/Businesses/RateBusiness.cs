using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class RateBusiness
    {
        public static Task<Rate> Add(Employee employee, Rate rate)
        {
            rate.Employee = employee;
            rate.RoomKind = rate.RoomKind.GetManaged();
            if (!rate.RoomKind.IsActive)
                throw new Exception("Loại phòng " + rate.RoomKind.Name + " đã ngưng hoại động");

            return RateDataAccess.Add(rate);
        }

        public static Task<Rate> Update(Employee employee, Rate rate)
        {
            var rateInDatabase = GetAndCheckValid(rate.Id);

            rate.Employee = employee;
            rate.RoomKind = rate.RoomKind.GetManaged();
            if (!rate.RoomKind.IsActive)
                throw new Exception("Loại phòng " + rate.RoomKind.Name + " đã ngưng hoại động");

            return RateDataAccess.Update(rateInDatabase, rate);
        }

        public static void Delete(int rateId)
        {
            var rateInDatabase = GetAndCheckValid(rateId);
            RateDataAccess.Delete(rateInDatabase);
        }

        private static Rate GetAndCheckValid(int rateId)
        {
            var rateInDatabase = Get(rateId);

            if (rateInDatabase == null)
                throw new Exception("Giá có Id: " + rateId + " không hợp lệ!");

            //TODO: kiểm tra điều kiện xóa sửa ở đây

            return rateInDatabase;
        }

        public static Rate Get(int rateId) => RateDataAccess.Get(rateId);
        public static IEnumerable<Rate> Get() => RateDataAccess.Get();
    }
}
