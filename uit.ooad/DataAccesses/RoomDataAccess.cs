using System;
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
        public static async Task<Room> Update(Room room)
        {
            await Database.WriteAsync(realm =>
            {
                room = realm.Add(room, update: true);
            });
            return room;
        }
        public static async void Delete(int id)
        {
            await Database.WriteAsync(realm =>
            {
                var room = Database.Find<Room>(id);
                realm.Remove(room);
            });
        }
        public static async void SetIsActive(int roomId, bool roomIsActive)
        {
            await Database.WriteAsync(realm =>
            {
                Database.Find<Room>(roomId).IsActive = roomIsActive;
            });
        }

        public static Room Get(int roomId) => Database.Find<Room>(roomId);

        public static IEnumerable<Room> Get() => Database.All<Room>();
    }
}
