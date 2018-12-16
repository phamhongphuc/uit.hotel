using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class BookingBusiness
    {
        public static Task<Booking> Add(Booking booking)
        {
            var bookingInDatabase = BookingDataAccess.Get(booking.Id);
            if (bookingInDatabase != null) return null;

            booking.Employee = booking.Employee.GetManaged();
            booking.Bill = booking.Bill.GetManaged();
            booking.Room = booking.Room.GetManaged();
            return BookingDataAccess.Add(booking);
        }

        public static Task<Booking> CheckIn(int bookingID)
        {
            var Booked = BookingDataAccess.Get(bookingID);

            //if (Booked == null)
            //    throw new CheckInException("Booking don't exists");
            //else
            {
                return BookingDataAccess.Update(Booked);
            }
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
