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
            booking.Status = (int)Booking.StatusEnum.Booked;
            return realm.Add(booking);
        }
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

        public static async Task<Booking> CheckIn(Employee employee, Booking bookingInDatabase, HouseKeeping houseKeeping)
        {
            await Database.WriteAsync(realm =>
            {
                bookingInDatabase.EmployeeCheckIn = employee;
                bookingInDatabase.RealCheckInTime = DateTimeOffset.Now;
                bookingInDatabase.Status = (int)Booking.StatusEnum.CheckedIn;

                HouseKeepingDataAccess.Add(realm, houseKeeping);
            });
            return bookingInDatabase;
        }

        internal static async Task<Booking> RequestCheckOut(Employee employee, Booking bookingInDatabase, HouseKeeping houseKeeping)
        {
            await Database.WriteAsync(realm =>
            {
                bookingInDatabase.EmployeeCheckOut = employee;
                bookingInDatabase.Status = (int)Booking.StatusEnum.RequestedCheckOut;

                HouseKeepingDataAccess.Add(realm, houseKeeping);
            });
            return bookingInDatabase;
        }

        // internal static Task<Booking> CheckOut(Booking bookingInDatabase, List<ServicesDetail> servicesDetails)
        // {
        //     throw new NotImplementedException();
        // }

        public static Booking Get(int bookingId) => Database.Find<Booking>(bookingId);

        public static IEnumerable<Booking> Get() => Database.All<Booking>();
    }
}
