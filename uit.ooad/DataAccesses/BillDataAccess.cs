using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class BillDataAccess : RealmDatabase
    {
        public static async Task<Bill> Add(Bill bill)
        {
            await Database.WriteAsync(realm =>
            {
                bill.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                bill = realm.Add(bill);
            });
            return bill;
        }

        public static Bill Get(int billId) => Database.Find<Bill>(billId);

        public static IEnumerable<Bill> Get() => Database.All<Bill>();
    }
}
