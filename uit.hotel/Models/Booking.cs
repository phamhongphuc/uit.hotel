using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using uit.hotel.Businesses;

namespace uit.hotel.Models
{
    public class Booking : RealmObject
    {
        public enum StatusEnum
        {
            Booked,
            CheckedIn,
            RequestedCheckOut,
            CheckedOut
        }

        [Ignored]
        public List<Patron> ListOfPatrons
        {
            set
            {
                if (IsManaged)
                    throw new Exception("Chỉ tạo setter cho trường dữ liệu này đối với đối tượng chưa được quản lý");
                foreach (var patron in value)
                    Patrons.Add(patron.GetManaged());
            }
        }

        [PrimaryKey]
        public int Id { get; set; }

        public int Status { get; set; }
        public DateTimeOffset BookCheckInTime { get; set; }
        public DateTimeOffset BookCheckOutTime { get; set; }
        public DateTimeOffset RealCheckInTime { get; set; }
        public DateTimeOffset RealCheckOutTime { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public Employee EmployeeBooking { get; set; }
        public Employee EmployeeCheckIn { get; set; }
        public Employee EmployeeCheckOut { get; set; }
        public Bill Bill { get; set; }
        public Room Room { get; set; }
        public IList<Patron> Patrons { get; }

        [Backlink(nameof(ServicesDetail.Booking))]
        public IQueryable<ServicesDetail> ServicesDetails { get; }

        public long Total
        {
            get
            {
                long total = 0;
                total += TotalServicesDetails;
                total += TotalRates;
                return total;
            }
        }

        public long TotalServicesDetails
        {
            get
            {
                long total = 0;
                foreach (var s in ServicesDetails) total += s.Total;
                return total;
            }
        }

        public long TotalRates
        {
            get
            {
                long total = 0;
                var date = RealCheckInTime;
                while (date <= RealCheckOutTime)
                {
                    var remain = RealCheckOutTime.Subtract(date).Days;
                    var rate = Room.RoomKind.GetRate(date);
                    if (remain >= 30)
                    {
                        total += rate.MonthRate;
                        date = date.AddDays(30);
                    }
                    else if (remain >= 7)
                    {
                        total += rate.WeekRate;
                        date = date.AddDays(7);
                    }
                    else
                    {
                        total += rate.DayRate;
                        date = date.AddDays(1);
                    }
                }

                return total;
            }
        }

        public long TotalVolatilityRate
        {
            get
            {
                long total = 0;
                return total;
            }
        }

        public Booking GetManaged()
        {
            var booking = BookingBusiness.Get(Id);
            if (booking == null)
                throw new Exception("Mã booking không tồn tại");
            return booking;
        }
    }
}
