using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class PatronKindDataAccess : RealmDatabase
    {
        public static async Task<PatronKind> Add(PatronKind patronKind)
        {
            await Database.WriteAsync(realm => patronKind = realm.Add(patronKind));
            return patronKind;
        }

        public static PatronKind Get(int patronKindId) => Database.Find<PatronKind>(patronKindId);

        public static IEnumerable<PatronKind> Get() => Database.All<PatronKind>();
    }
}
