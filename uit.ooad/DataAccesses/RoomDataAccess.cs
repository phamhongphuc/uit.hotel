using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class RoomDataAccess : RealmDatabase
    {
        public static async Task<Room> Add(Room room)
        {
            await Database.WriteAsync(realm => room = realm.Add(room));
            return room;
        }

        public static Room GetRoom(int roomId) => Database.Find<Room>(roomId);

        public static IEnumerable<Room> GetRooms() => Database.All<Room>();
    }
}
