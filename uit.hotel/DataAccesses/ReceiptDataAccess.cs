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
                receipt.Id = NextId;
                receipt.Time = DateTimeOffset.Now;
                receipt.Bill.CalculateTotalReceipts();
                realm.Add(receipt);
            });
            return receipt;
        }

        public static Receipt Get(int receiptId) => Database.Find<Receipt>(receiptId);

        public static IEnumerable<Receipt> Get() => Database.All<Receipt>();
    }
}
