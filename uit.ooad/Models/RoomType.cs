using System.Linq;
using Realms;

namespace uit.ooad.Models
{
    public class RoomType : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        public int NumberOfBeds { get; set; }
        public int AmountOfPeople { get; set; }
        public int PriceByDate { get; set; }

        [Backlink(nameof(Room.RoomType))]
        public IQueryable<Room> Rooms { get; }
        
        [Backlink(nameof(Rate.RoomType))]
        public IQueryable<Rate> Rates {get;}

        [Backlink(nameof(VolatilityRate.RoomType))]
        public IQueryable<VolatilityRate> VolatilityRates {get;}
    }
}
