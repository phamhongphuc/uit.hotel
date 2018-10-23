using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class FloorBusiness
    {
        internal static Task<Floor> Add(Floor floor) => FloorDataAccess.Add(floor);
    }
}
