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

            if (bookings.IsOverlap())
                throw new Exception("Có booking trùng nhau");

            foreach (var booking in bookings)
            {
                booking.EmployeeBooking = employee;
                booking.Room = booking.Room.GetManaged();
                if (!booking.Room.IsActive)
                    throw new Exception("Phòng " + booking.Room.Id + " đã ngừng hoạt động");

                if (booking.BookCheckInTime >= booking.BookCheckOutTime || booking.BookCheckInTime < DateTimeOffset.Now)
                    throw new Exception("Ngày check-in, check-out dự kiến không hợp lệ");

                if (!booking.IsEmpty())
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

            if (bookings.IsOverlap())
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

                if (!booking.IsEmpty(true))
                    throw new Exception("Phòng đã được đặt hoặc đang được sử dụng");

                if (booking.Patrons.Count() == 0)
                    throw new Exception("Phòng chưa có khách hàng");
            }

            return BillDataAccess.BookAndCheckIn(bill, bookings);
        }

        public static Task<Bill> Update(Bill bill)
        {
            var billInDatabase = Get(bill.Id);
            bill.Patron = bill.Patron.GetManaged();

            if (billInDatabase.Time != DateTimeOffset.MinValue)
                throw new Exception("Không thể cập nhật thông tin cho hóa đơn đã thanh toán");

            return BillDataAccess.Update(billInDatabase, bill);
        }

        public static Task<Bill> UpdateDiscount(Bill bill)
        {
            var billInDatabase = Get(bill.Id);
            if (billInDatabase.Time != DateTimeOffset.MinValue)
                throw new Exception("Không thể cập nhật giảm giá cho hóa đơn đã thanh toán");

            return BillDataAccess.UpdateDiscount(billInDatabase, bill);
        }

        public static Task<Bill> PayTheBill(Employee employee, int billId)
        {
            var billInDatabase = Get(billId);
            if (billInDatabase == null)
                throw new Exception("Mã bill không tồn tại");

            foreach (var booking in billInDatabase.Bookings)
            {
                if (booking.Status != BookingStatusEnum.CheckedOut)
                    throw new Exception("Có phòng chưa Check-out, không thể thanh toán");
            }

            if (billInDatabase.TotalPrice + billInDatabase.Discount != billInDatabase.TotalReceipts)
                throw new Exception("Chỉ có thể chốt hóa đơn khi đã thanh toán toàn bộ");

            return BillDataAccess.PayTheBill(employee, billInDatabase);
        }

        public static Bill Get(int billId) => BillDataAccess.Get(billId);
        public static IEnumerable<Bill> Get() => BillDataAccess.Get();
    }
}
