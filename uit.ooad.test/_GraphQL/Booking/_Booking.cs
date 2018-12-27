using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL.Booking
{
    [TestClass]
    public class _Booking
    {
        [TestMethod]
        public void Bookings()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/query.bookings.gql",
                @"/_GraphQL/Booking/query.bookings.schema.json"
            );
        }

        [TestMethod]
        public void Booking()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/query.booking.gql",
                @"/_GraphQL/Booking/query.booking.schema.json",
                @"/_GraphQL/Booking/query.booking.variable.json"
            );
        }

        [TestMethod]
        public void CheckIn()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                @"/_GraphQL/Booking/mutation.checkIn.schema.json",
                @"/_GraphQL/Booking/mutation.checkIn.variable.json",
                p => p.PermissionManageHiringRooms = true
            );
        }

        [TestMethod]
        public void RequestCheckOut()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.requestCheckOut.gql",
                @"/_GraphQL/Booking/mutation.requestCheckOut.schema.json",
                @"/_GraphQL/Booking/mutation.requestCheckOut.variable.json",
                p => p.PermissionManageHiringRooms = true
            );
        }

        [TestMethod]
        public void CheckOut()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                @"/_GraphQL/Booking/mutation.checkOut.schema.json",
                @"/_GraphQL/Booking/mutation.checkOut.variable.json",
                p => p.PermissionManageHiringRooms = true
            );
        }

        [TestMethod]
        public void AddBookingToBill()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                @"/_GraphQL/Booking/mutation.addBookingToBill.schema.json",
                @"/_GraphQL/Booking/mutation.addBookingToBill.variable.json",
                p => p.PermissionManageHiringRooms = true
            );
        }
    }
}
