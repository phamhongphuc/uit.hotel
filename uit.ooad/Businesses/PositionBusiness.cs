using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class PositionBusiness
    {
        public static Task<Position> Add(Position position)
        {
            var positionInDatabase = PositionDataAccess.Get(position.Id);
            if (positionInDatabase != null) return null;

            return PositionDataAccess.Add(position);
        }
        public static Position Get(int positionId) => PositionDataAccess.Get(positionId);
        public static IEnumerable<Position> Get() => PositionDataAccess.Get();
    }
}
