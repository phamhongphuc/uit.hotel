using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class BookingDataAccess : RealmDatabase
    {
        public static async Task<Booking> Add(Booking booking)
        {
            await Database.WriteAsync(realm => Add(realm, booking));
            return booking;
        }

        public static Booking Add(Realm realm, Booking booking)
        {
            booking.Id = NextId;
            booking.CreateTime = DateTimeOffset.Now;
            booking.Status = 1;
            return realm.Add(booking);
        }
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

        public static async Task<Booking> CheckIn(Employee employee, Booking bookingInDatabase)
        {
            await Database.WriteAsync(realm =>
            {
                bookingInDatabase.EmployeeCheckIn = employee;
                bookingInDatabase.RealCheckInTime = DateTimeOffset.Now;
                bookingInDatabase.Status = 2;
            });
            return bookingInDatabase;
        }

        public static Booking Get(int bookingId) => Database.Find<Booking>(bookingId);

        public static IEnumerable<Booking> Get() => Database.All<Booking>();
    }
}
