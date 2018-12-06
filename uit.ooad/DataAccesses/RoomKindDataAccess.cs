using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class RoomKindDataAccess : RealmDatabase
    {
        public static async Task<RoomKind> Add(RoomKind roomKind)
        {
            await Database.WriteAsync(realm => roomKind = realm.Add(roomKind));
            return roomKind;
        }

        public static RoomKind GetRoomKind(int roomKindId) => Database.Find<RoomKind>(roomKindId);
        public static IEnumerable<RoomKind> GetRoomKinds() => Database.All<RoomKind>();
    }
}
