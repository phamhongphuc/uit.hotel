using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class FloorBusiness
    {
        public static Task<Floor> Add(Floor floor) => FloorDataAccess.Add(floor);

        public static Task<Floor> Update(Floor floor)
        {
            var floorInDatabase = GetAndCheckValid(floor.Id);
            return FloorDataAccess.Update(floorInDatabase, floor);
        }

        public static void Delete(int floorId)
        {
            var floorInDatabase = GetAndCheckValid(floorId);
            FloorDataAccess.Delete(floorInDatabase);
        }

        public static void SetIsActive(int floorId, bool isActive)
        {
            var floorInDatabase = Get(floorId);
            if (floorInDatabase == null)
                throw new Exception("Tầng có Id: " + floorId + " không hợp lệ!");
            FloorDataAccess.SetIsActive(floorInDatabase, isActive);
        }

        private static Floor GetAndCheckValid(int floorId)
        {
            var floorInDatabase = Get(floorId);

            if (floorInDatabase == null)
                throw new Exception("Tầng có Id: " + floorId + " không hợp lệ!");

            if (!floorInDatabase.IsActive)
                throw new Exception("Tầng " + floorId + " đã ngưng hoạt động. Không thể cập nhật/xóa!");

            if (floorInDatabase.Rooms.Count() > 0)
                throw new Exception("Tầng đã có phòng. Không thể cập nhật/xóa!");
            return floorInDatabase;
        }

        public static Floor Get(int floorId) => FloorDataAccess.Get(floorId);
        public static IEnumerable<Floor> Get() => FloorDataAccess.Get();
    }
}
