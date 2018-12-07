using System;
using System.Collections.Generic;
using System.Linq;
using Realms;

namespace uit.ooad.Models
{
    public class Booking : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset CheckOutTime { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public int Status { get; set; }
        public Employee Employee { get; set; }
        public Bill Bill { get; set; }
        public Room Room { get; set; }
        public IList<Patron> Patrons { get; }

        [Backlink(nameof(HouseKeeping.Booking))]
        public IQueryable<HouseKeeping> HouseKeepings { get; }

        [Backlink(nameof(ServicesDetail.Booking))]
        public IQueryable<ServicesDetail> ServicesDetails { get; }
    }
}
