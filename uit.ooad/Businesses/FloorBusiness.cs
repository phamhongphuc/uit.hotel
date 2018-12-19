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
            var floorInDatabase = FloorDataAccess.Get(floor.Id);
            if (floorInDatabase != null && floorInDatabase.Rooms.Count() > 0)
                throw new Exception("Tầng đã có phòng. Không thể cập nhật!");
            return FloorDataAccess.Update(floor);
        }
        public static Floor Get(int floorId) => FloorDataAccess.Get(floorId);
        public static IEnumerable<Floor> Get() => FloorDataAccess.Get();
    }
}
