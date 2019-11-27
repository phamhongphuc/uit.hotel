using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class PriceItemDataAccess : RealmDatabase
    {
        public static async Task<PriceItem> Add(PriceItem priceItem)
        {
            await Database.WriteAsync(realm => priceItem = realm.Add(priceItem));
            return priceItem;
        }

        public static Task Add(IEnumerable<PriceItem> priceItems)
        {
            return WriteAsync(realm =>
            {
                foreach (var priceTime in priceItems)
                    realm.Add(priceTime);
            });
        }

        public static Task Delete(PriceItem priceItemInDatabase)
            => Database.WriteAsync(realm => realm.Remove(priceItemInDatabase));

        public static Task Delete(IEnumerable<PriceItem> priceItemInDatabases)
        {
            return WriteAsync(realm =>
            {
                foreach (var priceTime in priceItemInDatabases)
                    realm.Remove(priceTime);
            });
        }
    }
}
