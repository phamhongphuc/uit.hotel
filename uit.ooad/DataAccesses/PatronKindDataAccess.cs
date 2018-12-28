using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class PatronKindDataAccess : RealmDatabase
    {
        public static async Task<PatronKind> Add(PatronKind patronKind)
        {
            await Database.WriteAsync(realm =>
            {
                patronKind.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                patronKind = realm.Add(patronKind);
            });
            return patronKind;
        }

        public static PatronKind Get(int patronKindId) => Database.Find<PatronKind>(patronKindId);

        public static IEnumerable<PatronKind> Get() => Database.All<PatronKind>();
    }
}
