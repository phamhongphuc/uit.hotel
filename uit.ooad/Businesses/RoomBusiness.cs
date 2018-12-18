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
            room.RoomKind = room.RoomKind.GetManaged();
            return RoomDataAccess.Add(room);
        }
        public static Task<Room> Update(Room room)
        {
            var roomInDatabase = RoomDataAccess.Get(room.Id);
            if (roomInDatabase.Bookings.Count() > 0)
                throw new Exception("Phòng không thể cập nhật! Phòng đã có giao dịch trước đó. Yêu cầu vô hiệu hóa");
            room.Floor = room.Floor.GetManaged();
            room.RoomKind = room.RoomKind.GetManaged();
            return RoomDataAccess.Update(room);
        }
        public static void Delete(int id)
        {
            var roomInDatabase = RoomDataAccess.Get(id);
            if (roomInDatabase.Bookings.Count() > 0)
                throw new Exception("Phòng không thể xóa! Phòng đã có giao dịch trước đó. Yêu cầu vô hiệu hóa");
            RoomDataAccess.Delete(id);
        }
        public static void SetIsActive(int id, bool isActive)
        {
            var roomInDatabase = RoomDataAccess.Get(id);
            if (roomInDatabase == null) throw new Exception("Id=" + id + " không tồn tại");
            RoomDataAccess.SetIsActive(id, isActive);
        }
        public static Room Get(int roomId) => RoomDataAccess.Get(roomId);
        public static IEnumerable<Room> Get() => RoomDataAccess.Get();
    }
}
