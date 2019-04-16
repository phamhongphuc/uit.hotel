using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class ReceiptDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<Receipt> Add(Receipt receipt)
        {
            await Database.WriteAsync(realm =>
            {
                Add(realm, receipt);
            });
            return receipt;
        }

        public static void Add(Realm realm, Receipt receipt)
        {
            receipt.Id = NextId;
            receipt.Time = DateTimeOffset.Now;
            realm.Add(receipt);
        }

        public static Receipt Get(int receiptId) => Database.Find<Receipt>(receiptId);

        public static IEnumerable<Receipt> Get() => Database.All<Receipt>();

    }
}
