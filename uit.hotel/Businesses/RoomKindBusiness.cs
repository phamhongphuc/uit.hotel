using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class RoomKindBusiness
    {
        public static Task<RoomKind> Add(RoomKind roomKind) => RoomKindDataAccess.Add(roomKind);

        public static Task<RoomKind> Update(RoomKind roomKind)
        {
            var roomKindInDatabase = GetAndCheckValid(roomKind.Id);
            return RoomKindDataAccess.Update(roomKindInDatabase, roomKind);
        }

        public static void Delete(int roomKindId)
        {
            var roomKindInDatabase = GetAndCheckValid(roomKindId);
            RoomKindDataAccess.Delete(roomKindInDatabase);
        }

        public static void SetIsActive(int roomKindId, bool isActive)
        {
            var roomKindInDatabase = Get(roomKindId);
            if (roomKindInDatabase == null)
                throw new Exception("Loại phòng có Id: " + roomKindId + " không hợp lệ!");
            RoomKindDataAccess.SetIsActive(roomKindInDatabase, isActive);
        }

        private static RoomKind GetAndCheckValid(int roomKindId)
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
