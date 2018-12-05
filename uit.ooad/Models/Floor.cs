using System.Linq;
using Realms;

namespace uit.ooad.Models
{
    public class Floor : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        [Backlink(nameof(Room.Floor))]
        public IQueryable<Room> Rooms { get; }

        public Room[] fakeMethod()
        {
            return Realm.All<Room>().Where(r => r.Floor == this).ToArray();
        }
    }
}
