using System;
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
            await Database.WriteAsync(realm => booking = realm.Add(booking));
            return booking;
        }

        public static bool CheckBooking(int bookingID)
        {
            return Get(bookingID) != null;
        }

        public static async Task<Booking> Update(Booking booking)
        {
            await Database.WriteAsync(realm => booking = realm.Add(booking, update:true));
            return booking;

            // Tại sao cái Tread này lại Throw Exception
            //new Thread(() =>
            //{
            //    var theDog = Database.All<Booking>().Where(books => books.Id == booking.Id).First();
            //    Database.Write(() => booking.CheckInTime = DateTimeOffset.Now);

            //}).Start();
        }

        public static Booking Get(int bookingId) => Database.Find<Booking>(bookingId);

        public static IEnumerable<Booking> Get() => Database.All<Booking>();
    }
}
