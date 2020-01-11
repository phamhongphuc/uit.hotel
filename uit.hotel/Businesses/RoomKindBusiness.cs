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
        public static Task<RoomKind> Add(RoomKind roomKind)
        {
            CheckUniqueName(roomKind);
            return RoomKindDataAccess.Add(roomKind);
        }

        public static Task<RoomKind> Update(RoomKind roomKind)
        {
            var roomKindInDatabase = GetAndCheckValid(roomKind.Id);
            CheckUniqueName(roomKind, true);

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

        private static void CheckUniqueName(RoomKind roomKind, bool isUpdate = false)
        {
            var numberOfRoomKinds = Get().Where(rk => rk.Name == roomKind.Name && (isUpdate ? rk.Id != roomKind.GetManaged().Id : true)).Count();
            if (numberOfRoomKinds == 1)
                throw new Exception("Loại phòng " + roomKind.Name + " đã được tạo.");
            else if (numberOfRoomKinds > 1)
                throw new Exception("Cơ sở dữ liệu lỗi!");
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
