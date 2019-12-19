using System.Collections.Generic;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class ReceiptBusiness
    {
        public static Task<Receipt> AddCash(Employee employee, Receipt receipt)
        {
            receipt.Bill = receipt.Bill.GetManaged();
            receipt.Employee = employee;
            return ReceiptDataAccess.Add(receipt);
        }

        public static Receipt Get(int receiptId) => ReceiptDataAccess.Get(receiptId);

        public static IEnumerable<Receipt> Get() => ReceiptDataAccess.Get();
    }
}
