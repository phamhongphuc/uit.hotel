using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Bill : RealmDatabase
    {
        [TestMethod]
        public void Mutation_BookAndCheckIn()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.schema.json",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_BookAndCheckIn_InvalidPatron()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã khách hàng không tồn tại",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.variable.invalid_patron.json",
                p => p.PermissionManageHiringRoom = true
            );
        }
        [TestMethod]
        public void Mutation_BookAndCheckIn_InvalidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã phòng không tồn tại",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.variable.invalid_room.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/mutation.createBill.gql",
                @"/_GraphQL/Bill/mutation.createBill.schema.json",
                @"/_GraphQL/Bill/mutation.createBill.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill_InvalidPatron()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã khách hàng không tồn tại",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                @"/_GraphQL/Bill/mutation.createBill.variable.invalid_patron.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill_InvalidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã phòng không tồn tại",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                @"/_GraphQL/Bill/mutation.createBill.variable.invalid_room.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Query_Bill()
        {
            Database.WriteAsync(realm => realm.Add(new Bill
            {
                Id = 10,
                Time = DateTimeOffset.Now,
                Patron = PatronBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/query.bill.gql",
                @"/_GraphQL/Bill/query.bill.schema.json",
                @"/_GraphQL/Bill/query.bill.variable.json",
                p => p.PermissionGetAccountingVoucher = true
            );
        }

        [TestMethod]
        public void Query_Bills()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/query.bills.gql",
                @"/_GraphQL/Bill/query.bills.schema.json",
                null,
                p => p.PermissionGetAccountingVoucher = true
            );
        }
    }
}
