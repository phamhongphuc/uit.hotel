using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class PatronDataAccess : RealmDatabase
    {
        public static async Task<Patron> Add(Patron patron)
        {
            await Database.WriteAsync(realm => patron = realm.Add(patron));
            return patron;
        }

        public static Patron Get(string patronId) => Database.Find<Patron>(patronId);

        public static IEnumerable<Patron> Get() => Database.All<Patron>();
    }
}
