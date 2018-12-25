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
            RoomKind roomKindInDatabase = CheckValid(roomKind.Id);
            return RoomKindDataAccess.Update(roomKindInDatabase, roomKind);
        }

        public static void Delete(int roomKindId)
        {
            RoomKind roomKindInDatabase = CheckValid(roomKindId);
            RoomKindDataAccess.Delete(roomKindInDatabase);
        }

        private static RoomKind CheckValid(int roomKindId)
        {
            var roomKindInDatabase = Get(roomKindId);
            if (roomKindInDatabase == null)
                throw new Exception("Loại phòng có Id: " + roomKindId + " không tồn tại");

            if (!roomKindInDatabase.IsActive)
                throw new Exception("Loại phòng có Id: " + roomKindId + " đã ngừng cung cấp. Không thể cập nhật/xóa!");

            if (roomKindInDatabase.Rooms.Count() > 0)
                throw new Exception("Loại phòng đã có phòng sử dụng, không thể cập nhật/xóa!");
            return roomKindInDatabase;
        }

        public static RoomKind Get(int roomKindId) => RoomKindDataAccess.Get(roomKindId);
        public static IEnumerable<RoomKind> Get() => RoomKindDataAccess.Get();
    }
}
