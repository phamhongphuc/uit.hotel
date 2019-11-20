using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using uit.hotel.Businesses;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Models
{
    public partial class Booking : RealmObject
    {
        public enum StatusEnum
        {
            Booked,
            CheckedIn,
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

        [Ignored]
        public long Total { get => TotalPrice + TotalVolatilityPrice + TotalServicesDetails; }
        public long TotalPrice { get; set; }
        public long TotalVolatilityPrice { get; set; }
        public long TotalServicesDetails { get; set; }

        public void CalculateTotal(bool updateBill = false)
        {
            if (Status == (int)StatusEnum.CheckedOut)
                throw new Exception("Phòng đã checkout, không thể tính toán lại giá tiền.");

            CalculatePrice();
            CalculateServicesDetails();
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
