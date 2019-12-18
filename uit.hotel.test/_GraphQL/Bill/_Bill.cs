using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
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
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new { patron = new { id = 1 } }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_BookAndCheckIn_InvalidDate()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Ngày check-out dự kiến không hợp lệ",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(-2),
                            room = new { id = 1 },
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new { patron = new { id = 1 } }
                },
                p => p.PermissionManageRentingRoom = true
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
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new { patron = new { id = 100 } }
                },
                p => p.PermissionManageRentingRoom = true
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
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new { patron = new { id = 1 } }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_BookAndCheckIn_InvalidRoom_Empty()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Phòng đã được đặt hoặc đang được sử dụng",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 1 },
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new { patron = new { id = 1 } }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_BookAndCheckIn_InvalidRoom_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 110,
                IsActive = false,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Phòng 110 đã ngừng hoạt động",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 110 },
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new { patron = new { id = 1 } }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_BookAndCheckIn_InvalidRoom_Overlap()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 111,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Có booking trùng nhau",
                @"/_GraphQL/Bill/mutation.bookAndCheckIn.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 111 },
                            listOfPatrons = new[] { new { id = 1 } }
                        },
                        new
                        {
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(1),
                            room = new { id = 111 },
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new { patron = new { id = 1 } }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 120,
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
                            room = new { id = 120 },
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 1 }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill_InvalidDate()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Ngày check-in, check-out dự kiến không hợp lệ",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckInTime = DateTimeOffset.Now.AddDays(10),
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 1 },
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 1 }
                    }
                },
                p => p.PermissionManageRentingRoom = true
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
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 100 }
                    }
                },
                p => p.PermissionManageRentingRoom = true
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
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 1 }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }
        [TestMethod]
        public void Mutation_CreateBill_InvalidRoom_Empty()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Phòng đã được đặt hoặc đang được sử dụng",
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
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 1 }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill_InvalidRoom_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 121,
                IsActive = false,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Phòng 121 đã ngừng hoạt động",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 121 },
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 1 }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateBill_InvalidRoom_Overlap()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 122,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Có booking trùng nhau",
                @"/_GraphQL/Bill/mutation.createBill.gql",
                new
                {
                    bookings = new[]
                    {
                        new
                        {
                            bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 122 },
                            listOfPatrons = new[] { new { id = 1 } }
                        },
                        new
                        {
                            bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                            bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                            room = new { id = 122 },
                            listOfPatrons = new[] { new { id = 1 } }
                        }
                    },
                    bill = new
                    {
                        patron = new { id = 1 }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateBill()
        {
            Database.WriteAsync(realm => realm.Add(new Bill
            {
                Id = 10,
                Patron = PatronBusiness.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Bill/mutation.updateBill.gql",
                @"/_GraphQL/Bill/mutation.updateBill.schema.json",
                new
                {
                    input = new
                    {
                        id = 10,
                        discount = -100000,
                        patron = new { id = 1 }
                    },
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateBillDiscount()
        {
            Database.WriteAsync(realm => realm.Add(new Bill
            {
                Id = 20,
                Patron = PatronBusiness.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Bill/mutation.updateBillDiscount.gql",
                @"/_GraphQL/Bill/mutation.updateBillDiscount.schema.json",
                new
                {
                    input = new
                    {
                        id = 20,
                        discount = 100000,
                    },
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Query_Bill()
        {
            Database.WriteAsync(realm => realm.Add(new Bill
            {
                Id = 30,
                Time = DateTimeOffset.Now,
                Patron = PatronBusiness.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Bill/query.bill.gql",
                @"/_GraphQL/Bill/query.bill.schema.json",
                new { id = 30 },
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
