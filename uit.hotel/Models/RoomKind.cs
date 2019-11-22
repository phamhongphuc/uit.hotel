using System;
using System.Collections.Generic;
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

        [Backlink(nameof(Price.RoomKind))]
        public IQueryable<Price> Prices { get; }

        [Backlink(nameof(VolatilityPrice.RoomKind))]
        public IQueryable<VolatilityPrice> VolatilityPrices { get; }

        public Price GetPrice(DateTimeOffset date)
        {
            Price selected = null;
            foreach (var p in Prices)
                if (
                    date >= p.EffectiveStartDate &&
                    (selected == null || selected.EffectiveStartDate < p.EffectiveStartDate)
                )
                    selected = p;
            if (selected == null) throw new Exception("Loại phòng này chưa được cài đặt giá");
            return selected;
        }

        public IList<VolatilityPrice> GetVolatilityPrices(DateTimeOffset from, DateTimeOffset to)
        {
            IList<VolatilityPrice> selecteds = new List<VolatilityPrice> { };
            foreach (var v in VolatilityPrices)
            {
                if (v.EffectiveStartDate <= to && from <= v.EffectiveEndDate)
                    selecteds.Add(v);
            }
            return selecteds;
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
