using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Businesses
{
    public class BillBusiness
    {
        public static Task<Bill> Add(Employee employee, Bill bill)
        {
            bill.Patron = bill.Patron.GetManaged();
            bill.Employee = employee;

            return BillDataAccess.Add(bill);
        }

        public static Bill Get(int billId) => BillDataAccess.Get(billId);
        public static IEnumerable<Bill> Get() => BillDataAccess.Get();

    }
}
