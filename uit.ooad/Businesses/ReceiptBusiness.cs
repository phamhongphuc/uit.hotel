using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class ReceiptBusiness
    {
        public static Task<Receipt> Add(Receipt receipt)
        {
            var receiptInDatabase = ReceiptDataAccess.Get(receipt.Id);
            if (receiptInDatabase != null) return null;

            return ReceiptDataAccess.Add(receipt);
        }
        public static IEnumerable<Receipt> Get() => ReceiptDataAccess.Get();
    }
}
