using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class VolatilityPriceBusiness
    {
        public static Task<VolatilityPrice> Add(Employee employee, VolatilityPrice volatilityPrice)
        {
            volatilityPrice.Employee = employee;
            volatilityPrice.RoomKind = volatilityPrice.RoomKind.GetManaged();
            if (!volatilityPrice.RoomKind.IsActive)
                throw new Exception("Loại phòng " + volatilityPrice.RoomKind.Id + " đã ngưng hoại động");

            return VolatilityPriceDataAccess.Add(volatilityPrice);
        }

        public static Task<VolatilityPrice> Update(Employee employee, VolatilityPrice volatilityPrice)
        {
            var volatilityPriceInDatabase = GetAndCheckValid(volatilityPrice.Id);

            volatilityPrice.Employee = employee;
            volatilityPrice.RoomKind = volatilityPrice.RoomKind.GetManaged();
            if (!volatilityPrice.RoomKind.IsActive)
                throw new Exception("Loại phòng " + volatilityPrice.RoomKind.Id + " đã ngưng hoại động");

            return VolatilityPriceDataAccess.Update(volatilityPriceInDatabase, volatilityPrice);
        }

        public static void Delete(int volatilityPriceId)
        {
            var volatilityPriceInDatabase = GetAndCheckValid(volatilityPriceId);
            VolatilityPriceDataAccess.Delete(volatilityPriceInDatabase);
        }

        private static VolatilityPrice GetAndCheckValid(int volatilityPriceId)
        {
            var volatilityPriceInDatabase = Get(volatilityPriceId);

            if (volatilityPriceInDatabase == null)
                throw new Exception("Giá có Id: " + volatilityPriceId + " không hợp lệ!");

            //TODO: kiểm tra điều kiện xóa sửa ở đây

            return volatilityPriceInDatabase;
        }

        public static VolatilityPrice Get(int volatilityPriceId) => VolatilityPriceDataAccess.Get(volatilityPriceId);
        public static IEnumerable<VolatilityPrice> Get() => VolatilityPriceDataAccess.Get();
    }
}
