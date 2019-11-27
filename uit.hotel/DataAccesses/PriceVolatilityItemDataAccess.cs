using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class PriceVolatilityItemDataAccess : RealmDatabase
    {
        public static async Task<PriceVolatilityItem> Add(PriceVolatilityItem priceVolatilityItem)
        {
            await Database.WriteAsync(realm => priceVolatilityItem = realm.Add(priceVolatilityItem));
            return priceVolatilityItem;
        }

        public static Task Add(IEnumerable<PriceVolatilityItem> priceVolatilityItems)
        {
            return WriteAsync(realm =>
            {
                foreach (var priceVolatilityItem in priceVolatilityItems)
                    realm.Add(priceVolatilityItem);
            });
        }

        public static Task Delete(PriceVolatilityItem priceVolatilityItemInDatabase)
            => Database.WriteAsync(realm => realm.Remove(priceVolatilityItemInDatabase));

        public static Task Delete(IEnumerable<PriceVolatilityItem> priceVolatilityItemInDatabases)
        {
            return WriteAsync(realm =>
            {
                foreach (var priceVolatilityItem in priceVolatilityItemInDatabases)
                    realm.Remove(priceVolatilityItem);
            });
        }
    }
}
