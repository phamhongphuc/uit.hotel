using System.Linq;
using Realms;
using uit.ooad.Businesses;

namespace uit.ooad.Models
{
    public class RoomKind : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }
        public int NumberOfBeds { get; set; }
        public int AmountOfPeople { get; set; }
        public int PriceByDate { get; set; }

        [Backlink(nameof(Room.RoomKind))]
        public IQueryable<Room> Rooms { get; }

        [Backlink(nameof(Rate.RoomKind))]
        public IQueryable<Rate> Rates { get; }

        [Backlink(nameof(VolatilityRate.RoomKind))]
        public IQueryable<VolatilityRate> VolatilityRates { get; }

        public RoomKind GetManaged() => RoomKindBusiness.Get(Id);
    }
}
