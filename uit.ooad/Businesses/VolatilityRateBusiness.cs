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

        public static Task<VolatilityRate> Update(Employee employee, VolatilityRate volatilityRate)
        {
            var volatilityRateInDatabase = GetAndCheckValid(volatilityRate.Id);

            volatilityRate.Employee = employee;
            volatilityRate.RoomKind = volatilityRate.RoomKind.GetManaged();
            if (!volatilityRate.RoomKind.IsActive)
                throw new Exception("Loại phòng " + volatilityRate.RoomKind.Name + " đã ngưng hoại động");

            return VolatilityRateDataAccess.Update(volatilityRateInDatabase, volatilityRate);
        }

        public static void Delete(int volatilityRateId)
        {
            var volatilityRateInDatabase = GetAndCheckValid(volatilityRateId);
            VolatilityRateDataAccess.Delete(volatilityRateInDatabase);
        }

        private static VolatilityRate GetAndCheckValid(int volatilityRateId)
        {
            var volatilityRateInDatabase = Get(volatilityRateId);

            if (volatilityRateInDatabase == null)
                throw new Exception("Giá có Id: " + volatilityRateId + " không hợp lệ!");

            //TODO: kiểm tra điều kiện xóa sửa ở đây

            return volatilityRateInDatabase;
        }
        public static VolatilityRate Get(int volatilityRateId) => VolatilityRateDataAccess.Get(volatilityRateId);
        public static IEnumerable<VolatilityRate> Get() => VolatilityRateDataAccess.Get();

    }
}
