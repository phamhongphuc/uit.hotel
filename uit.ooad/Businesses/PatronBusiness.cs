using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class PatronBusiness
    {
        public static Task<Patron> Add(Patron patron)
        {
            var patronInDatabase = PatronDataAccess.Get(patron.Identification);
            if (patronInDatabase != null) return null;

            return PatronDataAccess.Add(patron);
        }
        public static Patron Get(string patronId) => PatronDataAccess.Get(patronId);
        public static IEnumerable<Patron> Get() => PatronDataAccess.Get();
    }
}
