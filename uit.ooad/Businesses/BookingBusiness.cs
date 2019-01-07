using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public static class BookingBusiness
    {
        public static Task<Booking> CheckIn(Employee employee, int bookingId)
        {
            var bookingInDatabase = Get(bookingId);
            if (bookingInDatabase == null)
                throw new Exception("Mã Booking không tồn tại");
            if (bookingInDatabase.Status != (int)Booking.StatusEnum.Booked)
                throw new Exception("Phòng đã được check-in, không thể check-in lại");

            var houseKeeping = new HouseKeeping();
            houseKeeping.Type = (int)HouseKeeping.TypeEnum.ExpectedArrival;
            houseKeeping.Status = (int)HouseKeeping.StatusEnum.Pending;
            houseKeeping.Booking = bookingInDatabase;

            return BookingDataAccess.CheckIn(employee, bookingInDatabase, houseKeeping);
        }

        public static Task<Booking> RequestCheckOut(Employee employee, int bookingId)
        {
            var bookingInDatabase = Get(bookingId);

            if (bookingInDatabase == null)
                throw new Exception("Mã Booking không tồn tại");
            if (bookingInDatabase.Status != (int)Booking.StatusEnum.CheckedIn)
                throw new Exception("Không thể yêu cầu trả phòng");

            var houseKeeping = new HouseKeeping();
            houseKeeping.Type = (int)HouseKeeping.TypeEnum.ExpectedDeparture;
            houseKeeping.Status = (int)HouseKeeping.StatusEnum.Pending;
            houseKeeping.Booking = bookingInDatabase;

            return BookingDataAccess.RequestCheckOut(employee, bookingInDatabase, houseKeeping);
        }

        public static Task<Booking> CheckOut(Employee employee, int bookingId)
        {
            var bookingInDatabase = Get(bookingId);
            if (bookingInDatabase == null)
                throw new Exception("Mã Booking không tồn tại");
            if (bookingInDatabase.Status != (int)Booking.StatusEnum.RequestedCheckOut)
                throw new Exception("Booking chưa thực hiện yêu cầu check-out");
            if (!bookingInDatabase.EmployeeCheckOut.Equals(employee))
                throw new Exception("Nhân viên không được phép check-out");

            return BookingDataAccess.CheckOut(bookingInDatabase);
        }

        public static void Cancel(int bookingId)
        {
            var bookingInDatabase = Get(bookingId);
            if (bookingInDatabase == null)
                throw new Exception("Mã Booking không tồn tại");

            if (bookingInDatabase.Status != (int)Booking.StatusEnum.Booked)
                throw new Exception("Không thể hủy đặt phòng. Booking đã hoặc đang được sử dụng.");

            if (bookingInDatabase.Bill.Bookings.Count() == 1) BillDataAccess.Delete(bookingInDatabase.Bill);

            BookingDataAccess.Delete(bookingInDatabase);
        }
        public static Task<Booking> Add(Employee employee, Bill bill, Booking booking)
        {
            bill = bill.GetManaged();
            booking.Room = booking.Room.GetManaged();

            if (!booking.Room.IsActive)
                throw new Exception("Phòng có Id: " + booking.Room.Id + " đã ngưng hoạt động");

            if (booking.BookCheckInTime >= booking.BookCheckOutTime || booking.BookCheckInTime < DateTimeOffset.Now)
                throw new Exception("Ngày check-in, check-out dự kiến không hợp lệ");

            if (!booking.Room.IsEmptyRoom(booking.BookCheckInTime, booking.BookCheckOutTime))
                throw new Exception("Phòng đã được đặt hoặc đang được sử dụng");

            return BookingDataAccess.Add(employee, bill, booking);
        }

        public static Booking Get(int bookingId) => BookingDataAccess.Get(bookingId);
        public static IEnumerable<Booking> Get() => BookingDataAccess.Get();
    }
}
