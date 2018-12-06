using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class RoomKindBusiness
    {
        public static Task<RoomKind> Add(RoomKind roomKind) => RoomKindDataAccess.Add(roomKind);
        public static RoomKind Get(int roomKindId) => RoomKindDataAccess.GetRoomKind(roomKindId);
        public static IEnumerable<RoomKind> Get() => RoomKindDataAccess.GetRoomKinds();
    }
}