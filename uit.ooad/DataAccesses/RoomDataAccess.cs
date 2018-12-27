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

        public static async Task<Room> Update(Room roomInDatabase, Room room)
        {
            await Database.WriteAsync(realm =>
            {
                roomInDatabase.Name = room.Name;
                roomInDatabase.Floor = room.Floor;
                roomInDatabase.RoomKind = room.RoomKind;
            });
            return roomInDatabase;
        }

        public static async void Delete(Room room)
        {
            await Database.WriteAsync(realm => realm.Remove(room));
        }

        public static async void SetIsActive(Room room, bool roomIsActive)
        {
            await Database.WriteAsync(realm => room.IsActive = roomIsActive);
        }

        public static Room Get(int roomId) => Database.Find<Room>(roomId);

        public static IEnumerable<Room> Get() => Database.All<Room>();
    }
}
