using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class ReceiptDataAccess : RealmDatabase
    {
        public static async Task<Receipt> Add(Receipt receipt)
        {
            await Database.WriteAsync(realm => receipt = realm.Add(receipt));
            return receipt;
        }

        public static Receipt Get(int receiptId) => Database.Find<Receipt>(receiptId);

        public static IEnumerable<Receipt> Get() => Database.All<Receipt>();
    }
}
