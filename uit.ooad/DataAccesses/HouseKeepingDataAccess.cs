using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class HouseKeepingDataAccess : RealmDatabase
    {
        public static async Task<HouseKeeping> Add(HouseKeeping houseKeeping)
        {
            await Database.WriteAsync(realm =>
            {
                houseKeeping.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                houseKeeping = realm.Add(houseKeeping);
            });
            return houseKeeping;
        }

        public static HouseKeeping Get(int houseKeepingId) => Database.Find<HouseKeeping>(houseKeepingId);

        public static IEnumerable<HouseKeeping> Get() => Database.All<HouseKeeping>();
    }
}
