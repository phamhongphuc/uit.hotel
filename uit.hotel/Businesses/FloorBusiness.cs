using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class FloorBusiness
    {
        public static Task<Floor> Add(Floor floor)
        {
            CheckUniqueName(floor);
            return FloorDataAccess.Add(floor);
        }

        public static Task<Floor> Update(Floor floor)
        {
            var floorInDatabase = GetAndCheckValid(floor.Id);
            CheckUniqueName(floor);

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

        private static void CheckUniqueName(Floor floor)
        {
            var numberOfFloors = Get().Where(f => f.Name == floor.Name).Count();
            if (numberOfFloors == 1)
                throw new Exception("Tầng " + floor.Name + " đã được tạo.");
            else if (numberOfFloors > 1)
                throw new Exception("Cơ sở dữ liệu lỗi!");
        }

        private static Floor GetAndCheckValid(int floorId)
        {
            var floorInDatabase = Get(floorId);

            NotNull(floorId, floorInDatabase);
            NotInactive(floorId, floorInDatabase);
            NotHasRoom(floorInDatabase);
            return floorInDatabase;
        }

        public static Floor Get(int floorId)
        {
            var floor = FloorDataAccess.Get(floorId);
            NotNull(floorId, floor);
            return floor;
        }

        public static IEnumerable<Floor> Get() => FloorDataAccess.Get();

        private static void NotHasRoom(Floor floorInDatabase)
        {
            if (floorInDatabase.Rooms.Count() > 0)
                throw new Exception("Tầng đã có phòng. Không thể cập nhật/xóa!");
        }

        private static void NotInactive(int floorId, Floor floorInDatabase)
        {
            if (!floorInDatabase.IsActive)
                throw new Exception("Tầng " + floorId + " đã ngưng hoạt động. Không thể cập nhật/xóa!");
        }

        private static void NotNull(int floorId, Floor floorInDatabase)
        {
            if (floorInDatabase == null)
                throw new Exception("Tầng có Id: " + floorId + " không hợp lệ!");
        }
    }
}
