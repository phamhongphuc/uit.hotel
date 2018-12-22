using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class BookingBusiness
    {
        public static Task<Booking> Add(Bill bill, Booking booking, Employee employee)
        {
            booking.Employee = employee;
            booking.Bill = bill;
            booking.Room = booking.Room.GetManaged();

            var patrons = new List<Patron>();
            foreach (var patron in booking.Patrons)
            {
                patrons.Add(patron.GetManaged());
                booking.Patrons.Remove(patron);
            }
            foreach (var patron in patrons) booking.Patrons.Add(patron);
            
            return BookingDataAccess.Add(booking);
        }

        public static Task<Booking> CheckIn(int bookingID)
        {
            var booking = Get(bookingID);
            if (booking == null) throw new Exception("Không tìm thấy booking");

            return BookingDataAccess.CheckIn(booking, DateTimeOffset.Now);
        }

        public static Booking Get(int bookingId) => BookingDataAccess.Get(bookingId);
        public static IEnumerable<Booking> Get() => BookingDataAccess.Get();


        public class CheckInException : Exception
        {
            public CheckInException()
            {
                // Todo Something else
            }

            public CheckInException(string Messages) : base(Messages)
            {
                // Todo fuck me if u want
            }
        }
    }
}
