using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class PriceVolatilityItemBusiness
    {
        public static Task<PriceVolatilityItem> Add(PriceVolatilityItem priceItem)
            => PriceVolatilityItemDataAccess.Add(priceItem);

        public static void Add(IEnumerable<PriceVolatilityItem> priceItems)
            => PriceVolatilityItemDataAccess.Add(priceItems);

        public static void Delete(PriceVolatilityItem priceItem)
            => PriceVolatilityItemDataAccess.Delete(priceItem);

        public static void Delete(IEnumerable<PriceVolatilityItem> priceItems)
            => PriceVolatilityItemDataAccess.Delete(priceItems);
    }
}
