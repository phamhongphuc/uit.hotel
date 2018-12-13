using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL.Receipt
{
    [TestClass]
    public class _Receipt
    {
        [TestMethod]
        public void Receipts()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Receipt/query.receipts.gql",
                @"/_GraphQL/Receipt/query.receipts.schema.json"
            );
        }
        // [TestMethod]
        // public void Receipt()
        // {
        //     SchemaHelper.Execute(
        //         @"/_GraphQL/Receipt/query.receipt.gql",
        //         @"/_GraphQL/Receipt/query.receipt.schema.json"
        //     );
        // }
        // [TestMethod]
        // public void CreateReceipt()
        // {
        //     SchemaHelper.Execute(
        //         @"/_GraphQL/Receipt/mutation.createReceipt.gql",
        //         @"/_GraphQL/Receipt/mutation.createReceipt.schema.json",
        //         @"/_GraphQL/Receipt/mutation.createReceipt.variable.json",
        //         p => p.PermissionCreateReceipt = true
        //     );
        // }
    }
}
