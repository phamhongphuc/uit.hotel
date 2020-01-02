using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                realm.Add(receipt);

                receipt.Bill.CalculateTotalReceipts();
            });
            return receipt;
        }

        public static async Task<Receipt> UpdatePayUrl(Receipt receipt, string payUrl)
        {
            await Database.WriteAsync(realm => receipt.PayUrl = payUrl);
            return receipt;
        }

        public static async Task<Receipt> UpdateStatus(Receipt receipt, ReceiptStatusEnum status, string statusText)
        {
            await Database.WriteAsync(realm =>
            {
                receipt.Status = status;
                receipt.StatusText = statusText;

                receipt.Bill.CalculateTotalReceipts();
            });
            return receipt;
        }

        public static Task Delete(Receipt receiptInDatabase)
            => Database.WriteAsync(realm => realm.Remove(receiptInDatabase));

        public static Receipt Get(int receiptId) => Database.Find<Receipt>(receiptId);

        public static IEnumerable<Receipt> Get() => Database.All<Receipt>();
    }
}
