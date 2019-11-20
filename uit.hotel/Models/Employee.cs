using System;
using System.Linq;
using Realms;
using uit.hotel.Businesses;
using uit.hotel.Queries.Authentication;

namespace uit.hotel.Models
{
    public class Employee : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string IdentityCard { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public DateTimeOffset StartingDate { get; set; }
        public Position Position { get; set; }
        public bool IsActive { get; set; }

        [Backlink(nameof(Bill.Employee))]
        public IQueryable<Bill> Bills { get; }

        [Backlink(nameof(Receipt.Employee))]
        public IQueryable<Receipt> Receipts { get; }

        [Backlink(nameof(Price.Employee))]
        public IQueryable<Price> Prices { get; }

        [Backlink(nameof(VolatilityPrice.Employee))]
        public IQueryable<Price> VolatilityPrices { get; }

        [Backlink(nameof(Booking.EmployeeBooking))]
        public IQueryable<Booking> Bookings { get; }

        [Backlink(nameof(Booking.EmployeeCheckIn))]
        public IQueryable<Booking> CheckIns { get; }

        [Backlink(nameof(Booking.EmployeeCheckOut))]
        public IQueryable<Booking> CheckOuts { get; }

        public bool IsEqualPassword(string rawPassword)
        {
            return CryptoHelper.Encrypt(rawPassword).Equals(Password);
        }

        public Employee GetManaged()
        {
            var employee = EmployeeBusiness.Get(Id);
            if (employee == null)
                throw new Exception("Tên đăng nhập không tồn tại");
            return employee;
        }
    }
}
