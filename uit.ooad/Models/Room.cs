using System.Linq;
using Realms;
using uit.ooad.Businesses;

namespace uit.ooad.Models
{
    public class Room : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }
        public Floor Floor { get; set; }
        public RoomKind RoomKind { get; set; }
        public bool IsActive { get; set; }

        [Backlink(nameof(Booking.Room))]
        public IQueryable<Booking> Bookings { get; }
        public Room GetManaged() => RoomBusiness.Get(Id);
    }
}
