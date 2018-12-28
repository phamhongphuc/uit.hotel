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
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

        public static async Task<Booking> Add(Employee employee, Bill bill, Booking booking)
        {
            await Database.WriteAsync(realm =>
            {
                booking.EmployeeBooking = employee;
                booking.Bill = bill;
                Add(realm, booking);
            });
            return booking;
        }

        public static Booking Add(Realm realm, Booking booking)
        {
            booking.Id = NextId;
            booking.CreateTime = DateTimeOffset.Now;
            booking.Status = (int)Booking.StatusEnum.Booked;
            return realm.Add(booking);
        }

        public static Booking BookAndCheckIn(Realm realm, Booking booking)
        {
            booking.Id = NextId;
            booking.CreateTime = DateTimeOffset.Now;
            booking.RealCheckInTime = DateTimeOffset.Now;
            booking.Status = (int)Booking.StatusEnum.CheckedIn;

            booking = realm.Add(booking);

            var houseKeeping = new HouseKeeping();
            houseKeeping.Type = (int)HouseKeeping.TypeEnum.ExpectedArrival;
            houseKeeping.Status = (int)HouseKeeping.StatusEnum.Pending;
            houseKeeping.Booking = booking;

            HouseKeepingDataAccess.Add(realm, houseKeeping);

            return booking;
        }

        public static async Task<Booking> CheckIn(Employee employee, Booking bookingInDatabase,
                                                  HouseKeeping houseKeeping)
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

        public static async Task<Booking> RequestCheckOut(Employee employee, Booking bookingInDatabase,
                                                            HouseKeeping houseKeeping)
        {
            await Database.WriteAsync(realm =>
            {
                bookingInDatabase.EmployeeCheckOut = employee;
                bookingInDatabase.Status = (int)Booking.StatusEnum.RequestedCheckOut;

                HouseKeepingDataAccess.Add(realm, houseKeeping);
            });
            return bookingInDatabase;
        }

        public static async Task<Booking> CheckOut(Booking bookingInDatabase)
        {
            await Database.WriteAsync(realm =>
            {
                bookingInDatabase.RealCheckOutTime = DateTimeOffset.Now;
                bookingInDatabase.Status = (int)Booking.StatusEnum.CheckedOut;
            });
            return bookingInDatabase;
        }

        public static Booking Get(int bookingId) => Database.Find<Booking>(bookingId);

        public static IEnumerable<Booking> Get() => Database.All<Booking>();
    }
}
