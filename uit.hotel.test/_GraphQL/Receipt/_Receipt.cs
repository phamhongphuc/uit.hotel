using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.Queries.Helper;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _Receipt : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateReceipt()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Receipt/mutation.createReceipt.gql",
                @"/_GraphQL/Receipt/mutation.createReceipt.schema.json",
                new
                {
                    input = new
                    {
                        money = 1000,
                        bill = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateReceipt_InvalidBill()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã hóa đơn không tồn tại",
                @"/_GraphQL/Receipt/mutation.createReceipt.gql",
                new
                {
                    input = new
                    {
                        money = 1000,
                        bill = new
                        {
                            id = 100
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Query_Receipt()
        {
            Database.WriteAsync(realm => realm.Add(new Receipt
            {
                Id = 10,
                Money = 1,
                Bill = BillBusiness.Get(1),
                Employee = EmployeeBusiness.Get(Constant.AdminName)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Receipt/query.receipt.gql",
                @"/_GraphQL/Receipt/query.receipt.schema.json",
                new { id = 10 },
                p => p.PermissionGetAccountingVoucher = true
            );
        }

        [TestMethod]
        public void Query_Receipts()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Receipt/query.receipts.gql",
                @"/_GraphQL/Receipt/query.receipts.schema.json",
                null,
                p => p.PermissionGetAccountingVoucher = true
            );
        }
    }
}
