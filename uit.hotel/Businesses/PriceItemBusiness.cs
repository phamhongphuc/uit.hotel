using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class PriceItemBusiness
    {
        public static Task<PriceItem> Add(PriceItem priceItem)
            => PriceItemDataAccess.Add(priceItem);

        public static void Add(IEnumerable<PriceItem> priceItems)
            => PriceItemDataAccess.Add(priceItems);

        public static void Delete(PriceItem priceItem)
            => PriceItemDataAccess.Delete(priceItem);

        public static void Delete(IEnumerable<PriceItem> priceItems)
            => PriceItemDataAccess.Delete(priceItems);
    }
}
