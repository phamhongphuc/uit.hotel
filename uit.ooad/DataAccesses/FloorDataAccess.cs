using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class FloorDataAccess : RealmDatabase
    {
        public static async Task<Floor> Add(Floor floor)
        {
            await Database.WriteAsync(realm => floor = realm.Add(floor));
            return floor;
        }

        public static Floor Get(int floorId) => Database.Find<Floor>(floorId);

        public static IEnumerable<Floor> Get() => Database.All<Floor>();
    }
}
