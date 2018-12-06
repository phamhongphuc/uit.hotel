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
            
            return BookingDataAccess.Add(booking);
        }
        public static Booking Get(int bookingId) => BookingDataAccess.Get(bookingId);
        public static IEnumerable<Booking> Get() => BookingDataAccess.Get();
    }
}
