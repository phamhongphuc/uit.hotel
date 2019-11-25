using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class PriceVolatilityBusiness
    {
        public static Task<PriceVolatility> Add(Employee employee, PriceVolatility priceVolatility)
        {
            priceVolatility.Employee = employee;
            priceVolatility.RoomKind = priceVolatility.RoomKind.GetManaged();
            if (!priceVolatility.RoomKind.IsActive)
                throw new Exception("Loại phòng " + priceVolatility.RoomKind.Id + " đã ngưng hoại động");

            return PriceVolatilityDataAccess.Add(priceVolatility);
        }

        public static Task<PriceVolatility> Update(Employee employee, PriceVolatility priceVolatility)
        {
            var priceVolatilityInDatabase = GetAndCheckValid(priceVolatility.Id);

            priceVolatility.Employee = employee;
            priceVolatility.RoomKind = priceVolatility.RoomKind.GetManaged();
            if (!priceVolatility.RoomKind.IsActive)
                throw new Exception("Loại phòng " + priceVolatility.RoomKind.Id + " đã ngưng hoại động");

            return PriceVolatilityDataAccess.Update(priceVolatilityInDatabase, priceVolatility);
        }

        public static void Delete(int priceVolatilityId)
        {
            var priceVolatilityInDatabase = GetAndCheckValid(priceVolatilityId);
            PriceVolatilityDataAccess.Delete(priceVolatilityInDatabase);
        }

        private static PriceVolatility GetAndCheckValid(int priceVolatilityId)
        {
            var priceVolatilityInDatabase = Get(priceVolatilityId);

            if (priceVolatilityInDatabase == null)
                throw new Exception("Giá có Id: " + priceVolatilityId + " không hợp lệ!");

            //TODO: kiểm tra điều kiện xóa sửa ở đây

            return priceVolatilityInDatabase;
        }

        public static PriceVolatility Get(int priceVolatilityId) => PriceVolatilityDataAccess.Get(priceVolatilityId);
        public static IEnumerable<PriceVolatility> Get() => PriceVolatilityDataAccess.Get();
    }
}
