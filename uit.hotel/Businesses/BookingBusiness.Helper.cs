using System;
using System.Collections.Generic;
using System.Linq;
using uit.hotel.Models;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Businesses
{
    public class BookingEquality : IEqualityComparer<Booking>
    {
        public static BookingEquality Instance = new BookingEquality();

        //kiểm tra trùng -> true
        public bool Equals(Booking x, Booking y)
            => x.Room.Id == y.Room.Id && DateTimeHelper.IsOverlap(
                x.CheckInTime, x.CheckOutTime,
                y.CheckInTime, y.CheckOutTime
            );

        public int GetHashCode(Booking booking)
            => booking.Room.Id;
    }

    public static class BookingBusinessHelper
    {
        public static bool IsOverlap(this IList<Booking> bookings)
            => bookings.Count() != bookings.ToList().Distinct(BookingEquality.Instance).Count();

        public static bool IsEmpty(this Booking booking, bool isCheckInNow = false)
            => booking.Room.IsEmpty(
                isCheckInNow ? DateTimeOffset.Now : booking.CheckInTime,
                booking.CheckOutTime,
                booking
            );
    }
}
