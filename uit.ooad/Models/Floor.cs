using System;
using System.Linq;
using Realms;
using uit.ooad.Businesses;

namespace uit.ooad.Models
{
    public class Floor : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        [Backlink(nameof(Room.Floor))]
        public IQueryable<Room> Rooms { get; }

        public Room[] fakeMethod()
        {
            return Realm.All<Room>().Where(r => r.Floor == this).ToArray();
        }

        public Floor GetManaged()
        {
            var floor = FloorBusiness.Get(Id);
            if (floor == null)
                throw new Exception("Mã tầng không tồn tại");
            return floor;
        }
    }
}
