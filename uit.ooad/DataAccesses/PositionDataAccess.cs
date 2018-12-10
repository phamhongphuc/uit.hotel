using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class PositionDataAccess : RealmDatabase
    {
        public static async Task<Position> Add(Position position)
        {
            await Database.WriteAsync(realm => position = realm.Add(position));
            return position;
        }

        public static Position Get(int positionId) => Database.Find<Position>(positionId);

        public static async void Update(Action<Position> setPermission, Position position)
            => await Database.WriteAsync(realm => { setPermission(position); });

        public static IEnumerable<Position> Get() => Database.All<Position>();
    }
}
