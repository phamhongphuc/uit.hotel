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
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 1 },
                            listOfPatrons = new[] { new { id = 1 } },
                        }
                    },
                    bill = new { patron = new { id = 1 } }
                },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_BookAndCheckIn_InvalidPatron()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã khách hàng không tồn tại",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 1 },
                            listOfPatrons = new[] { new { id = 1 } },
                        }
                    },
                    bill = new { patron = new { id = 100 } }
                },
                p => p.PermissionManageHiringRoom = true
            );
        }
        [TestMethod]
        public void Mutation_BookAndCheckIn_InvalidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã phòng không tồn tại",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 100 },
                            listOfPatrons = new[] { new { id = 1 } },
                        }
                    },
                    bill = new { patron = new { id = 1 } }
                },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 110,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Bill/mutation.createBill.gql",
                @"/_GraphQL/Bill/mutation.createBill.schema.json",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 110 },
                            listOfPatrons = new[] { new { id = 1 } },
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 1 }
                    }
                },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill_InvalidPatron()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã khách hàng không tồn tại",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 1 },
                            listOfPatrons = new[] { new { id = 1 } },
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 100 }
                    }
                },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill_InvalidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã phòng không tồn tại",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 100 },
                            listOfPatrons = new[] { new { id = 1 } },
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 1 }
                    }
                },
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
                new { id = 10 },
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
