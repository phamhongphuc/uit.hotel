using System;
using System.Collections.Generic;
using System.Linq;
using uit.hotel.Models;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Businesses
{
    public class BookingEquality : IEqualityComparer<Booking>
    {
        //kiểm tra trùng -> true
        public bool Equals(Booking x, Booking y)
            => x.Room.Id == y.Room.Id && DateTimeHelper.IsTwoDateRangesOverlap(
                x.CheckInTime, x.CheckOutTime,
                y.CheckInTime, y.CheckOutTime
            );

        public int GetHashCode(Booking booking)
            => booking.Room.Id;
    }

    public static class BookingEqualityHelper
    {
        static BookingEquality BookingEquality = new BookingEquality();

        public static bool IsOverlap(this IList<Booking> bookings)
            => bookings.Count() != bookings.ToList().Distinct(BookingEquality).Count();
    }
}
