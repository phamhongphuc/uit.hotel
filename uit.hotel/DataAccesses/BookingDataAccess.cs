using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class BookingDataAccess : RealmDatabase
    {
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

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
            booking.BookCheckInTime = DateTimeOffset.Now;
            booking.RealCheckInTime = DateTimeOffset.Now;
            booking.Status = (int)Booking.StatusEnum.CheckedIn;

            booking = realm.Add(booking);
            return booking;
        }

        public static async Task<Booking> CheckIn(Employee employee, Booking bookingInDatabase)
        {
            await Database.WriteAsync(realm =>
            {
                bookingInDatabase.EmployeeCheckIn = employee;
                bookingInDatabase.RealCheckInTime = DateTimeOffset.Now;
                bookingInDatabase.Status = (int)Booking.StatusEnum.CheckedIn;
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

        public static async void Delete(Booking bookingInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(bookingInDatabase));
        }

        public static Booking Get(int bookingId) => Database.Find<Booking>(bookingId);

        public static IEnumerable<Booking> Get() => Database.All<Booking>();
    }
}
