using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class PriceBusiness
    {
        public static Task<Price> Add(Employee employee, Price price)
        {
            price.Employee = employee;
            price.RoomKind = price.RoomKind.GetManaged();
            if (!price.RoomKind.IsActive)
                throw new Exception("Loại phòng có ID: " + price.RoomKind.Id + " đã ngưng hoại động");

            return PriceDataAccess.Add(price);
        }

        public static Task<Price> Update(Employee employee, Price price)
        {
            var priceInDatabase = GetAndCheckValid(price.Id);

            price.Employee = employee;
            price.RoomKind = price.RoomKind.GetManaged();
            if (!price.RoomKind.IsActive)
                throw new Exception("Loại phòng " + price.RoomKind.Id + " đã ngưng hoại động");

            return PriceDataAccess.Update(priceInDatabase, price);
        }

        public static void Delete(int priceId)
        {
            var priceInDatabase = GetAndCheckValid(priceId);
            PriceDataAccess.Delete(priceInDatabase);
        }

        private static Price GetAndCheckValid(int priceId)
        {
            var priceInDatabase = Get(priceId);

            if (priceInDatabase == null)
                throw new Exception("Giá có Id: " + priceId + " không hợp lệ!");

            //TODO: kiểm tra điều kiện xóa sửa ở đây

            return priceInDatabase;
        }

        public static Price Get(int priceId) => PriceDataAccess.Get(priceId);
        public static IEnumerable<Price> Get() => PriceDataAccess.Get();
    }
}
