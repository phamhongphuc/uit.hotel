using System;
using System.Linq;
using Realms;
using uit.ooad.Businesses;
using uit.ooad.Queries.Authentication;

namespace uit.ooad.Models
{
    public class Employee : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public DateTimeOffset StartingDate { get; set; }
        public Position Position { get; set; }
        public bool IsActive { get; set; }

        [Backlink(nameof(Bill.Employee))]
        public IQueryable<Bill> Bills { get; }

        [Backlink(nameof(Receipt.Employee))]
        public IQueryable<Receipt> Receipts { get; }

        [Backlink(nameof(HouseKeeping.Employee))]
        public IQueryable<HouseKeeping> HouseKeepings { get; }

        [Backlink(nameof(Booking.Employee))]
        public IQueryable<Booking> Bookings { get; }

        public bool IsEqualPassword(string rawPassword)
        {
            return CryptoHelper.Encrypt(rawPassword).Equals(Password);
        }

        public Employee GetManaged() => EmployeeBusiness.Get(Id);
    }
}
