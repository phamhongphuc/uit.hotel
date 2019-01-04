using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Bill
{
    [TestClass]
    public class _Bill
    {
        [TestMethod]
        public void Bills()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/query.bills.gql",
                @"/_GraphQL/Bill/query.bills.schema.json",
                null,
                p => p.PermissionGetAccountingVoucher = true
            );
        }

        [TestMethod]
        public void Bill()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/query.bill.gql",
                @"/_GraphQL/Bill/query.bill.schema.json",
                @"/_GraphQL/Bill/query.bill.variable.json",
                p => p.PermissionGetAccountingVoucher = true
            );
        }

        [TestMethod]
        public void CreateBill()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/mutation.createBill.gql",
                @"/_GraphQL/Bill/mutation.createBill.schema.json",
                @"/_GraphQL/Bill/mutation.createBill.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void CreateBill_InValidPatron()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Exception has been thrown by the target of an invocation.",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                @"/_GraphQL/Bill/mutation.createBill.variable.in_valid_patron.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void CreateBill_InValidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã phòng không tồn tại",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                @"/_GraphQL/Bill/mutation.createBill.variable.in_valid_room.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void BookAndCheckIn()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.schema.json",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void BookAndCheckIn_InValidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã phòng không tồn tại",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.variable.in_valid_room.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void BookAndCheckIn_InValidPatron()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Exception has been thrown by the target of an invocation.",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.variable.in_valid_patron.json",
                p => p.PermissionManageHiringRoom = true
            );
        }
    }
}
