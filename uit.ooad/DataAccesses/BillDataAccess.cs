using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class BillDataAccess : RealmDatabase
    {
        public static async Task<Bill> Add(Bill bill)
        {
            await Database.WriteAsync(realm => bill = realm.Add(bill));
            return bill;
        }

        public static Bill Get(int billId) => Database.Find<Bill>(billId);

        public static IEnumerable<Bill> Get() => Database.All<Bill>();
    }
}
