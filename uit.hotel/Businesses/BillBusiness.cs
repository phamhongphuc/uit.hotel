using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Businesses
{
    public static class BillBusiness
    {
        public static Task<Bill> Book(Employee employee, Bill bill, List<Booking> bookings)
        {
            bill.Patron = bill.Patron.GetManaged();
            bill.Employee = employee;

            if (bookings.Count() == 0)
                throw new Exception("Chưa có booking nào");

            if (
                bookings.Count() !=
                bookings.ToList().Distinct(new EqualityBooking(Booking.StatusEnum.Booked)).Count()
            )
                throw new Exception("Có booking trùng nhau");

            foreach (var booking in bookings)
            {
                booking.EmployeeBooking = employee;
                booking.Room = booking.Room.GetManaged();
                if (!booking.Room.IsActive)
                    throw new Exception("Phòng " + booking.Room.Id + " đã ngừng hoạt động");

                if (booking.BookCheckInTime >= booking.BookCheckOutTime || booking.BookCheckInTime < DateTimeOffset.Now)
                    throw new Exception("Ngày check-in, check-out dự kiến không hợp lệ");

                if (!booking.Room.IsEmptyRoom(booking.BookCheckInTime, booking.BookCheckOutTime))
                    throw new Exception("Phòng đã được đặt hoặc đang được sử dụng");

                if (booking.Patrons.Count() == 0)
                    throw new Exception("Phòng chưa có khách hàng");
            }

            return BillDataAccess.Book(bill, bookings);
        }

        public static Task<Bill> BookAndCheckIn(Employee employee, Bill bill, List<Booking> bookings)
        {
            bill.Patron = bill.Patron.GetManaged();
            bill.Employee = employee;

            if (bookings.Count() == 0)
                throw new Exception("Chưa có booking nào");

            if (
                bookings.Count() !=
                bookings.ToList().Distinct(new EqualityBooking(Booking.StatusEnum.CheckedIn)).Count()
            )
                throw new Exception("Có booking trùng nhau");

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
                    throw new Exception("Phòng đã được đặt hoặc đang được sử dụng");

                if (booking.Patrons.Count() == 0)
                    throw new Exception("Phòng chưa có khách hàng");
            }

            return BillDataAccess.BookAndCheckIn(bill, bookings);
        }

        public static Bill Get(int billId) => BillDataAccess.Get(billId);
        public static IEnumerable<Bill> Get() => BillDataAccess.Get();

        public static Task<Bill> PayTheBill(Employee employee, int billId)
        {
            var billInDatabase = Get(billId);
            if (billInDatabase == null)
                throw new Exception("Mã bill không tồn tại");

            foreach (var booking in billInDatabase.Bookings)
            {
                if (booking.Status != (int)Booking.StatusEnum.CheckedOut)
                    throw new Exception("Có phòng chưa Check-out, không thể thanh toán");
            }

            return BillDataAccess.PayTheBill(employee, billInDatabase);
        }
    }

    public class EqualityBooking : IEqualityComparer<Booking>
    {
        public EqualityBooking(Booking.StatusEnum Kind)
        {
            this.Kind = Kind;
        }

        public Booking.StatusEnum Kind { get; set; }

        //kiểm tra trùng -> true
        public bool Equals(Booking x, Booking y)
        {
            if (Kind == Booking.StatusEnum.Booked)
            {
                if (x.Room.Id != y.Room.Id) return false;
                if (!DateTimeHelper.IsTwoDateRangesOverlap(
                        x.BookCheckInTime, x.BookCheckOutTime,
                        y.BookCheckInTime, y.BookCheckOutTime
                    ))
                    return false;
            }
            else if (Kind == Booking.StatusEnum.CheckedIn)
            {
                if (x.Room.Id != y.Room.Id) return false;
            }
            else throw new Exception("Lỗi hệ thống: Kind phải là Booked hoặc CheckedIn");

            return true;
        }

        public int GetHashCode(Booking obj)
        {
            return string.Format(
                "{0} {1} {2}", obj.Room.Id,
                obj.BookCheckInTime.Ticks, obj.BookCheckOutTime.Ticks
            ).GetHashCode();
        }
    }
}
