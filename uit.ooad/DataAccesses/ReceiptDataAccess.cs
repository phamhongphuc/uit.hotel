using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class ReceiptDataAccess : RealmDatabase
    {
        public static async Task<Receipt> Add(Receipt receipt)
        {
            await Database.WriteAsync(realm =>
            {
                receipt.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                receipt = realm.Add(receipt);
            });
            return receipt;
        }

        public static Receipt Get(int receiptId) => Database.Find<Receipt>(receiptId);

        public static IEnumerable<Receipt> Get() => Database.All<Receipt>();
    }
}
