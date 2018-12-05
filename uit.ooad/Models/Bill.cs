using System;
using System.Linq;
using Realms;

namespace uit.ooad.Models
{
    public class Bill : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public Patron Patron { get; set; }
        public Employee Employee { get; set; }

        [Backlink(nameof(Receipt.Bill))]
        public IQueryable<Receipt> Receipts { get; }

        [Backlink(nameof(Booking.Bill))]
        public IQueryable<Booking> Bookings { get; }
    }
}
