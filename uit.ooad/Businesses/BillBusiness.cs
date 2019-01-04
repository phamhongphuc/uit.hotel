using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public static class BillBusiness
    {
        public static Task<Bill> Book(Employee employee, Bill bill, List<Booking> bookings)
        {
            bill.Patron = bill.Patron.GetManaged();
            bill.Employee = employee;

            foreach (var booking in bookings)
            {
                booking.EmployeeBooking = employee;
                booking.Room = booking.Room.GetManaged();
                if (!booking.Room.IsActive)
                    throw new Exception("Phòng " + booking.Room.Id + " đã ngừng hoạt động");

                if (booking.BookCheckInTime > booking.BookCheckOutTime || booking.BookCheckInTime < DateTimeOffset.Now)
                    throw new Exception("Ngày check-in, check-out dự kiến không hợp lệ");

                if (!booking.Room.IsEmptyRoom(booking.BookCheckInTime, booking.BookCheckOutTime))
                    throw new Exception("Phòng đã được đặt hoạc đang được sử dụng");
                booking.CheckValidBeforeCreate();
            }

            return BillDataAccess.Book(bill, bookings);
        }

        public static Task<Bill> BookAndCheckIn(Employee employee, Bill bill, List<Booking> bookings)
        {
            bill.Patron = bill.Patron.GetManaged();
            bill.Employee = employee;

            foreach (var booking in bookings)
            {
                booking.EmployeeBooking = employee;
                booking.EmployeeCheckIn = employee;
                booking.Room = booking.Room.GetManaged();
                if (!booking.Room.IsActive)
                    throw new Exception("Phòng " + booking.Room.Id + " đã ngừng hoạt động");

                if (booking.BookCheckOutTime < DateTimeOffset.Now)
                    throw new Exception("Ngày check-out dự kiến không hợp lệ");

                if (!booking.Room.IsEmptyRoom(DateTimeOffset.Now, booking.BookCheckOutTime))
                    throw new Exception("Phòng đã được đặt hoạc đang được sử dụng");
            }

            return BillDataAccess.BookAndCheckIn(bill, bookings);
        }

        public static Bill Get(int billId) => BillDataAccess.Get(billId);
        public static IEnumerable<Bill> Get() => BillDataAccess.Get();
    }
}
