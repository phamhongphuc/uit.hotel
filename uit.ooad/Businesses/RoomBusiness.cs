using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class RoomBusiness
    {
        public static Task<Room> Add(Room room)
        {
            var roomInDatabase = RoomDataAccess.Get(room.Id);
            if (roomInDatabase != null) return null;

            return RoomDataAccess.Add(room);
        }
        public static Room Get(int roomId) => RoomDataAccess.Get(roomId);
        public static IEnumerable<Room> Get() => RoomDataAccess.Get();
    }
}
