using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;
using uit.hotel.Queries.Helper;

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

                booking.CalculateTotal();
            });
            return booking;
        }

        // Doesn't calculate anything. Add only.
        public static Booking Add(Realm realm, Booking booking)
        {
            booking.Id = NextId;
            booking.CreateTime = DateTimeOffset.Now;
            booking.Status = BookingStatusEnum.Booked;
            booking.BookCheckInTime = booking.BookCheckInTime.Round();
            booking.BookCheckOutTime = booking.BookCheckOutTime.Round();
            return realm.Add(booking);
        }

        // Doesn't calculate anything. Add only.
        public static Booking BookAndCheckIn(Realm realm, Booking booking)
        {
            booking.Id = NextId;
            booking.CreateTime = DateTimeOffset.Now.Round();
            booking.BookCheckInTime = DateTimeOffset.Now.Round();
            booking.RealCheckInTime = DateTimeOffset.Now.Round();
            booking.Status = BookingStatusEnum.CheckedIn;

            booking = realm.Add(booking);
            return booking;
        }

        public static async Task<Booking> CheckIn(Employee employee, Booking bookingInDatabase)
        {
            await Database.WriteAsync(realm =>
            {
                bookingInDatabase.EmployeeCheckIn = employee;
                bookingInDatabase.RealCheckInTime = DateTimeOffset.Now.Round();
                bookingInDatabase.Status = BookingStatusEnum.CheckedIn;

                bookingInDatabase.CalculateTotal();
            });
            return bookingInDatabase;
        }

        public static async Task<Booking> CheckOut(Booking bookingInDatabase, Employee employee)
        {
            await Database.WriteAsync(realm =>
            {
                bookingInDatabase.EmployeeCheckOut = employee;
                bookingInDatabase.RealCheckOutTime = DateTimeOffset.Now.Round();
                bookingInDatabase.CalculateTotal();

                bookingInDatabase.Status = BookingStatusEnum.CheckedOut;
                bookingInDatabase.Room.IsClean = false;
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
