using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class FloorDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<Floor> Add(Floor floor)
        {
            await Database.WriteAsync(realm =>
            {
                floor.Id = NextId;
                floor.IsActive = true;
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
