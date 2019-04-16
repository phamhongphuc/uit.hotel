using System;
using System.Linq;
using Realms;
using uit.hotel.Businesses;

namespace uit.hotel.Models
{
    public class RoomKind : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBeds { get; set; }
        public int AmountOfPeople { get; set; }
        public bool IsActive { get; set; }

        [Backlink(nameof(Room.RoomKind))]
        public IQueryable<Room> Rooms { get; }

        [Backlink(nameof(Rate.RoomKind))]
        public IQueryable<Rate> Rates { get; }

        [Backlink(nameof(VolatilityRate.RoomKind))]
        public IQueryable<VolatilityRate> VolatilityRates { get; }

        public Rate GetRate(DateTimeOffset date)
        {
            Rate select = null;
            foreach (var rate in Rates)
                if (
                    date >= rate.EffectiveStartDate &&
                    (select == null || select.EffectiveStartDate < rate.EffectiveStartDate)
                )
                    select = rate;
            if (select == null) throw new Exception("Loại phòng này chưa được cài đặt giá");
            return select;
        }

        public RoomKind GetManaged()
        {
            var roomKind = RoomKindBusiness.Get(Id);
            if (roomKind == null)
                throw new Exception("Mã loại phòng không tồn tại");
            return roomKind;
        }
    }
}
