using System.Linq;
using Realms;

namespace uit.ooad.Models
{
    public class Room : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        public Floor Floor { get; set; }
        public RoomKind RoomKind { get; set; }

        [Backlink(nameof(Booking.Room))]
        public IQueryable<Booking> Bookings { get; }
    }
}
