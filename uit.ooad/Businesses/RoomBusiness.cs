using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.Queries.Helper;

namespace uit.ooad.Businesses
{
    public static class RoomBusiness
    {
        public static Task<Room> Add(Room room)
        {
            room.Floor = room.Floor.GetManaged();
            if (!room.Floor.IsActive)
                throw new Exception("Tầng có ID: " + room.Floor.Id + " đã ngưng hoại động");

            room.RoomKind = room.RoomKind.GetManaged();
            if (!room.RoomKind.IsActive)
                throw new Exception("Loại phòng có ID: " + room.RoomKind.Id + " đã ngưng hoại động");

            return RoomDataAccess.Add(room);
        }

        public static Task<Room> Update(Room room)
        {
            var roomInDatabase = GetAndCheckValid(room.Id);

            room.Floor = room.Floor.GetManaged();
            if (!room.Floor.IsActive)
                throw new Exception("Tầng có ID: " + room.Floor.Id + " đã ngưng hoại động");

            room.RoomKind = room.RoomKind.GetManaged();
            if (!room.RoomKind.IsActive)
                throw new Exception("Loại phòng có ID: " + room.RoomKind.Id + " đã ngưng hoại động");

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
            if (isActive && !roomInDatabase.Floor.IsActive)
                throw new Exception("Loại phòng thuộc tầng đã bị vô hiệu hóa. Không thể kích hoạt");
            RoomDataAccess.SetIsActive(roomInDatabase, isActive);
        }

        private static Room GetAndCheckValid(int roomId)
        {
            var roomInDatabase = Get(roomId);
            if (roomInDatabase == null)
                throw new Exception("Phòng có Id: " + roomId + " không tồn tại");

            if (!roomInDatabase.IsActive)
                throw new Exception("Phòng " + roomInDatabase.Id + " đã ngưng hoại động. Không thể cập nhật/xóa!");

            if (roomInDatabase.Bookings.Count() > 0)
                throw new Exception("Phòng đã có giao dịch trước đó. Không thể cập nhật/xóa!");

            return roomInDatabase;
        }

        public static bool IsEmptyRoom(this Room room, DateTimeOffset from, DateTimeOffset to)
        {
            if (from > to) throw new Exception("Ngày đến < ngày đi");
            foreach (var booking in room.Bookings)
            {
                var status = booking.Status;
                DateTimeOffset bookingFrom;
                DateTimeOffset bookingTo;
                switch (status)
                {
                    case (int) Booking.StatusEnum.Booked:
                        bookingFrom = booking.BookCheckInTime;
                        bookingTo = booking.BookCheckOutTime;
                        break;
                    case 1:
                        bookingFrom = booking.RealCheckInTime;
                        bookingTo = booking.BookCheckOutTime;
                        break;
                    case 2:
                        bookingFrom = booking.RealCheckInTime;
                        bookingTo = booking.BookCheckOutTime;
                        break;
                    default:
                        bookingFrom = booking.RealCheckInTime;
                        bookingTo = booking.RealCheckOutTime;
                        break;
                }

                if (DateTimeHelper.IsTwoDateRangesOverlap(bookingFrom, bookingTo, from, to)) return false;
            }

            return true;
        }

        public static Room Get(int roomId) => RoomDataAccess.Get(roomId);
        public static IEnumerable<Room> Get() => RoomDataAccess.Get();
    }
}
