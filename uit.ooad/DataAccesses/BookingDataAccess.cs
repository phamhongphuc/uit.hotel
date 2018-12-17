using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class BookingDataAccess : RealmDatabase
    {
        public static async Task<Booking> Add(Booking booking)
        {
            await Database.WriteAsync(realm =>
            {
                booking.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                booking = realm.Add(booking);
            });
            return booking;
        }

        public static Booking Get(int bookingId) => Database.Find<Booking>(bookingId);

        public static IEnumerable<Booking> Get() => Database.All<Booking>();
    }
}
