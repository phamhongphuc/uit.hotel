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
            patron.PatronKind = patron.PatronKind.GetManaged();
            return PatronDataAccess.Add(patron);
        }

        public static Patron Get(int patronId) => PatronDataAccess.Get(patronId);
        public static IEnumerable<Patron> Get() => PatronDataAccess.Get();
    }
}
