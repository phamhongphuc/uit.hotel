using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class BillBusiness
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
            }

            return BillDataAccess.BookAndCheckIn(bill, bookings);
        }

        public static Bill Get(int billId) => BillDataAccess.Get(billId);
        public static IEnumerable<Bill> Get() => BillDataAccess.Get();
    }
}
