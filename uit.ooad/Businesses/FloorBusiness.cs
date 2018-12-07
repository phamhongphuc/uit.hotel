using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class FloorBusiness
    {
        public static Task<Floor> Add(Floor floor)
        {
            var floorInDatabase = FloorDataAccess.Get(floor.Id);
            if (floorInDatabase != null) return null;

            return FloorDataAccess.Add(floor);
        }

        public static Floor Get(int floorId) => FloorDataAccess.Get(floorId);
        public static IEnumerable<Floor> Get() => FloorDataAccess.Get();
    }
}
