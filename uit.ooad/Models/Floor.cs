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

        public Floor GetManaged()
        {
            var floor = FloorBusiness.Get(Id);
            return floor;
        }
    }
}
