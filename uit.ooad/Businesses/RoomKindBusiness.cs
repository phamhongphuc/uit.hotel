using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class RoomKindBusiness
    {
        public static Task<RoomKind> Add(RoomKind roomKind)        
        {
            var roomKindInDatabase = RoomKindDataAccess.Get(roomKind.Id);
            if (roomKindInDatabase != null) return null;

            return RoomKindDataAccess.Add(roomKind);
        }
        public static RoomKind Get(int roomKindId) => RoomKindDataAccess.Get(roomKindId);
        public static IEnumerable<RoomKind> Get() => RoomKindDataAccess.Get();
    }
}
