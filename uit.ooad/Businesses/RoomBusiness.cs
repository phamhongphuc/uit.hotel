using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class RoomBusiness
    {
        public static Task<Room> Add(Room room)
        {
            room.Floor = room.Floor.GetManaged();
            if (!room.Floor.IsActive)
                throw new Exception("Tầng " + room.Floor.Name + " đã ngưng hoại động");

            room.RoomKind = room.RoomKind.GetManaged();
            if (!room.RoomKind.IsActive)
                throw new Exception("Loại phòng " + room.RoomKind.Name + " đã ngưng hoại động");

            return RoomDataAccess.Add(room);
        }

        public static Task<Room> Update(Room room)
        {
            var roomInDatabase = GetAndCheckValid(room.Id);

            room.Floor = room.Floor.GetManaged();
            if (!room.Floor.IsActive)
                throw new Exception("Tầng " + room.Floor.Name + " đã ngưng hoại động");

            room.RoomKind = room.RoomKind.GetManaged();
            if (!room.RoomKind.IsActive)
                throw new Exception("Loại phòng " + room.RoomKind.Name + " đã ngưng hoại động");

            return RoomDataAccess.Update(roomInDatabase, room);
        }

        public static void Delete(int id)
        {
            var roomInDatabase = GetAndCheckValid(id);
            RoomDataAccess.Delete(roomInDatabase);
        }

        public static void SetIsActive(int id, bool isActive)
        {
            var roomInDatabase = Get(id);
            if (roomInDatabase == null) throw new Exception("Id: " + id + " không tồn tại");
            if(isActive && !roomInDatabase.Floor.IsActive)
                throw new Exception("Loại phòng thuộc tầng đã bị vô hiệu hóa. Không thể kích hoạt");
            RoomDataAccess.SetIsActive(roomInDatabase, isActive);
        }

        private static Room GetAndCheckValid(int roomId)
        {
            var roomInDatabase = Get(roomId);
            if (roomInDatabase == null)
                throw new Exception("Phòng có Id: " + roomId + " không tồn tại");

            if (!roomInDatabase.IsActive)
                throw new Exception("Phòng " + roomInDatabase.Name + " đã ngưng hoại động. Không thể cập nhật/xóa!");

            if (roomInDatabase.Bookings.Count() > 0)
                throw new Exception("Phòng đã có giao dịch trước đó. Không thể cập nhật/xóa!");

            return roomInDatabase;
        }

        public static Room Get(int roomId) => RoomDataAccess.Get(roomId);
        public static IEnumerable<Room> Get() => RoomDataAccess.Get();
    }
}
