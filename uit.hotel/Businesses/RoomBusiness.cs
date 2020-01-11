using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Businesses
{
    public static class RoomBusiness
    {
        public static Task<Room> Add(Room room)
        {
            CheckUniqueName(room);

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
            CheckUniqueName(room, true);

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
                throw new Exception("Phòng thuộc tầng đã bị vô hiệu hóa. Không thể kích hoạt");
            RoomDataAccess.SetIsActive(roomInDatabase, isActive);
        }

        public static void SetIsClean(int id, bool isClean)
        {
            var roomInDatabase = Get(id);
            if (roomInDatabase == null) throw new Exception("Id: " + id + " không tồn tại");
            if (!roomInDatabase.IsActive)
                throw new Exception("Phòng đã bị vô hiệu hóa. Không thể sửa trạng thái dọn phòng");

            RoomDataAccess.SetIsClean(roomInDatabase, isClean);
        }

        private static void CheckUniqueName(Room room, bool isUpdate = false)
        {
            var numberOfRooms = Get().Where(r => r.Name == room.Name && (isUpdate ? r.Id != room.GetManaged().Id : true)).Count();
            if (numberOfRooms == 1)
                throw new Exception("Phòng " + room.Name + " đã được tạo.");
            else if (numberOfRooms > 1)
                throw new Exception("Cơ sở dữ liệu lỗi!");
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

        public static bool IsEmpty(this Room room, DateTimeOffset from, DateTimeOffset to, Booking ignoreBooking = null)
        {
            if (from > to) throw new Exception("Ngày đến < ngày đi");
            foreach (var booking in room.Bookings)
            {
                if (ignoreBooking != null && booking.Id == ignoreBooking.Id) continue;
                if (DateTimeHelper.IsOverlap(
                    booking.CheckInTime,
                    booking.CheckOutTime,
                    from,
                    to
                )) return false;
            }

            return true;
        }

        public static Booking GetCurrentBooking(this Room room, DateTimeOffset from, DateTimeOffset to)
        {
            if (from > to) throw new Exception("Ngày đến < ngày đi");
            foreach (var booking in room.Bookings)
            {
                var status = booking.Status;
                DateTimeOffset bookingFrom;
                DateTimeOffset bookingTo;
                switch (status)
                {
                    case BookingStatusEnum.Booked:
                        bookingFrom = booking.BookCheckInTime;
                        bookingTo = booking.BookCheckOutTime;
                        break;
                    case BookingStatusEnum.CheckedIn:
                        bookingFrom = booking.RealCheckInTime;
                        bookingTo = booking.BookCheckOutTime;
                        break;
                    case BookingStatusEnum.CheckedOut:
                        bookingFrom = booking.RealCheckInTime;
                        bookingTo = booking.BookCheckOutTime;
                        break;
                    default:
                        bookingFrom = booking.RealCheckInTime;
                        bookingTo = booking.RealCheckOutTime;
                        break;
                }

                if (DateTimeHelper.IsOverlap(bookingFrom, bookingTo, from, to)) return booking;
            }

            return null;
        }

        public static Room Get(int roomId) => RoomDataAccess.Get(roomId);
        public static IEnumerable<Room> Get() => RoomDataAccess.Get();
    }
}
