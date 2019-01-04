using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Receipt
    {
        [TestMethod]
        public void Receipts()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Receipt/query.receipts.gql",
                @"/_GraphQL/Receipt/query.receipts.schema.json",
                null,
                p => p.PermissionGetAccountingVoucher = true
            );
        }

        [TestMethod]
        public void Receipt()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Receipt/query.receipt.gql",
                @"/_GraphQL/Receipt/query.receipt.schema.json",
                @"/_GraphQL/Receipt/query.receipt.variable.json",
                p => p.PermissionGetAccountingVoucher = true
            );
        }

        [TestMethod]
        public void CreateReceipt()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Receipt/mutation.createReceipt.gql",
                @"/_GraphQL/Receipt/mutation.createReceipt.schema.json",
                @"/_GraphQL/Receipt/mutation.createReceipt.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }
    }
}
