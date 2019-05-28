using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class BillDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<Bill> Book(Bill bill, List<Booking> bookings)
        {
            await Database.WriteAsync(realm =>
            {
                bill.Id = NextId;
                bill = realm.Add(bill);

                foreach (var booking in bookings)
                {
                    booking.Bill = bill;
                    BookingDataAccess.Add(realm, booking);
                }
            });
            return bill;
        }

        public static async Task<Bill> BookAndCheckIn(Bill bill, List<Booking> bookings)
        {
            await Database.WriteAsync(realm =>
            {
                bill.Id = NextId;
                bill = realm.Add(bill);

                foreach (var booking in bookings)
                {
                    booking.Bill = bill;
                    BookingDataAccess.BookAndCheckIn(realm, booking);
                }
            });
            return bill;
        }

        public static async Task<Bill> PayTheBill(Employee employee, Bill billInDatabase)
        {
            await Database.WriteAsync(realm =>
            {
                billInDatabase.Employee = employee;
                billInDatabase.Time = DateTimeOffset.Now;

                var receipt = new Receipt();
                receipt.Money = billInDatabase.Total - billInDatabase.TotalReceipts;
                receipt.Bill = billInDatabase;
                receipt.Employee = employee;

                ReceiptDataAccess.Add(realm, receipt);
            });
            return billInDatabase;
        }

        public static Bill Get(int billId) => Database.Find<Bill>(billId);

        public static IEnumerable<Bill> Get() => Database.All<Bill>();

        public static async void Delete(Bill bill) => await Database.WriteAsync(realm => realm.Remove(bill));
    }
}
