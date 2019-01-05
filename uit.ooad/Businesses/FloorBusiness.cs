using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public static class FloorBusiness
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
            if (!isActive && floorInDatabase.Rooms.Where(r => r.IsActive).Count() > 0)
                throw new Exception("Tầng này còn phòng đang hoạt động, không thể vô hiệu hóa");
            FloorDataAccess.SetIsActive(floorInDatabase, isActive);
        }

        private static Floor GetAndCheckValid(int floorId)
        {
            var floorInDatabase = Get(floorId);

            notNull(floorId, floorInDatabase);
            notInactive(floorId, floorInDatabase);
            notHasRoom(floorInDatabase);
            return floorInDatabase;
        }

        public static Floor Get(int floorId)
        {
            var floor = FloorDataAccess.Get(floorId);
            notNull(floorId, floor);
            return floor;
        }
        public static IEnumerable<Floor> Get() => FloorDataAccess.Get();

        private static void notHasRoom(Floor floorInDatabase)
        {
            if (floorInDatabase.Rooms.Count() > 0)
                throw new Exception("Tầng đã có phòng. Không thể cập nhật/xóa!");
        }

        private static void notInactive(int floorId, Floor floorInDatabase)
        {
            if (!floorInDatabase.IsActive)
                throw new Exception("Tầng " + floorId + " đã ngưng hoạt động. Không thể cập nhật/xóa!");
        }

        private static void notNull(int floorId, Floor floorInDatabase)
        {
            if (floorInDatabase == null)
                throw new Exception("Tầng có Id: " + floorId + " không hợp lệ!");
        }
    }
}
