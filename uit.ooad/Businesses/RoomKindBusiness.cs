using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class RoomKindBusiness
    {
        public static Task<RoomKind> Add(RoomKind roomKind) => RoomKindDataAccess.Add(roomKind);

        public static Task<RoomKind> Update(RoomKind roomKind)
        {
            var roomKindInDatabase = Get(roomKind.Id);
            if (roomKindInDatabase != null && roomKindInDatabase.Rooms.Count() > 0)
                throw new Exception("Không thể cập nhật! Loại phòng đã có phòng");
            return RoomKindDataAccess.Update(roomKindInDatabase, roomKind);
        }
        public static RoomKind Get(int roomKindId) => RoomKindDataAccess.Get(roomKindId);
        public static IEnumerable<RoomKind> Get() => RoomKindDataAccess.Get();
    }
}
