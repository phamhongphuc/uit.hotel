using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class BillBusiness
    {
        public static Task<Bill> Add(Bill bill)
        {
            var billInDatabase = BillDataAccess.Get(bill.Id);
            if (billInDatabase != null) return null;

            return BillDataAccess.Add(bill);
        }

        public static Bill Get(string billId) => BillDataAccess.Get(billId);
        public static IEnumerable<Bill> Get() => BillDataAccess.Get();
    }
}
