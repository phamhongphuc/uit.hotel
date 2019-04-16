using System;
using System.Linq;
using Realms;
using uit.hotel.Businesses;

namespace uit.hotel.Models
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

        public Room GetManaged()
        {
            var room = RoomBusiness.Get(Id);
            if (room == null)
                throw new Exception("Mã phòng không tồn tại");
            return room;
        }
    }
}
