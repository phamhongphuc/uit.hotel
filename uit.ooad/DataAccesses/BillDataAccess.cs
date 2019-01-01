using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
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

        public static Bill Get(int billId) => Database.Find<Bill>(billId);

        public static IEnumerable<Bill> Get() => Database.All<Bill>();
    }
}
