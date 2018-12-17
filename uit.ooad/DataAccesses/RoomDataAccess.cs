using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class RoomDataAccess : RealmDatabase
    {
        public static async Task<Room> Add(Room room)
        {
            await Database.WriteAsync(realm =>
            {
                room.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                room = realm.Add(room);
            });
            return room;
        }

        public static Room Get(int roomId) => Database.Find<Room>(roomId);

        public static IEnumerable<Room> Get() => Database.All<Room>();
    }
}
