using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class PatronKindDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<PatronKind> Add(PatronKind patronKind)
        {
            await Database.WriteAsync(realm =>
            {
                patronKind.Id = NextId;
                patronKind = realm.Add(patronKind);
            });
            return patronKind;
        }

        public static async Task<PatronKind> Update(PatronKind patronKindInDatabase, PatronKind patronKind)
        {
            await Database.WriteAsync(realm =>
            {
                patronKindInDatabase.Name = patronKind.Name;
                patronKindInDatabase.Description = patronKind.Description;
            });
            return patronKindInDatabase;
        }

        public static async void Delete(PatronKind patronKind)
        {
            await Database.WriteAsync(realm => realm.Remove(patronKind));
        }

        public static PatronKind Get(int patronKindId) => Database.Find<PatronKind>(patronKindId);

        public static IEnumerable<PatronKind> Get() => Database.All<PatronKind>();
    }
}
