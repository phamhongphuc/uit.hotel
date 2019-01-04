using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Booking
    {
        [TestMethod]
        public void Mutation_AddBookingToBill()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                @"/_GraphQL/Booking/mutation.addBookingToBill.schema.json",
                @"/_GraphQL/Booking/mutation.addBookingToBill.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_AddBookingToBill_InvalidBill()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã hóa đơn không tồn tại.",
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                @"/_GraphQL/Booking/mutation.addBookingToBill.variable.invalid_bill.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                @"/_GraphQL/Booking/mutation.checkIn.schema.json",
                @"/_GraphQL/Booking/mutation.checkIn.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn_InvalidBookingStatus()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Phòng đã được check-in, không thể check-in lại.",
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                @"/_GraphQL/Booking/mutation.checkIn.variable.invalid_booking_status.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã Booking không tồn tại",
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                @"/_GraphQL/Booking/mutation.checkIn.variable.invalid_id.json",
                p => p.PermissionManageHiringRoom = true
            );
        }
        [TestMethod]
        public void Mutation_CheckOut()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                @"/_GraphQL/Booking/mutation.checkOut.schema.json",
                @"/_GraphQL/Booking/mutation.checkOut.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckOut_InvalidBookingStatus()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Không thể Check-out.",
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                @"/_GraphQL/Booking/mutation.checkOut.variable.invalid_booking_status.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckOut_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã Booking không tồn tại.",
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                @"/_GraphQL/Booking/mutation.checkOut.variable.invalid_id.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_RequestCheckOut()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.requestCheckOut.gql",
                @"/_GraphQL/Booking/mutation.requestCheckOut.schema.json",
                @"/_GraphQL/Booking/mutation.requestCheckOut.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_RequestCheckOut_InvalidBookingStatus()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Không thể yêu cầu trả phòng",
                @"/_GraphQL/Booking/mutation.requestCheckOut.gql",
                @"/_GraphQL/Booking/mutation.requestCheckOut.variable.invalid_booking_status.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_RequestCheckOut_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã Booking không tồn tại",
                @"/_GraphQL/Booking/mutation.requestCheckOut.gql",
                @"/_GraphQL/Booking/mutation.requestCheckOut.variable.invalid_id.json",
                p => p.PermissionManageHiringRoom = true
            );
        }
        [TestMethod]
        public void Query_Booking()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/query.booking.gql",
                @"/_GraphQL/Booking/query.booking.schema.json",
                @"/_GraphQL/Booking/query.booking.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Query_Bookings()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/query.bookings.gql",
                @"/_GraphQL/Booking/query.bookings.schema.json",
                null,
                p => p.PermissionManageHiringRoom = true
            );
        }
    }
}
