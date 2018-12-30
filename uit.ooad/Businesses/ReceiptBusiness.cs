using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class ReceiptBusiness
    {
        public static Task<Receipt> Add(Employee employee, Receipt receipt)
        {
            receipt.Bill = receipt.Bill.GetManaged();
            receipt.Employee = employee;
            return ReceiptDataAccess.Add(receipt);
        }

        public static Receipt Get(int receiptId) => ReceiptDataAccess.Get(receiptId);

        public static IEnumerable<Receipt> Get() => ReceiptDataAccess.Get();
    }
}
