using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class FloorDataAccess : RealmDatabase
    {
        public static async Task<Floor> Add(Floor floor)
        {
            await Database.WriteAsync(realm =>
            {
                floor.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                floor = realm.Add(floor);
            });
            return floor;
        }

        public static async Task<Floor> Update(Floor floorInDatabase, Floor floor)
        {
            await Database.WriteAsync(realm => floorInDatabase.Name = floor.Name);
            return floorInDatabase;
        }

        public static async void Delete(Floor floor)
        {
            await Database.WriteAsync(realm => realm.Remove(floor));
        }

        public static async void SetIsActive(Floor floor, bool isActive)
        {
            await Database.WriteAsync(realm => floor.IsActive = isActive);
        }

        public static Floor Get(int floorId) => Database.Find<Floor>(floorId);

        public static IEnumerable<Floor> Get() => Database.All<Floor>();
    }
}
