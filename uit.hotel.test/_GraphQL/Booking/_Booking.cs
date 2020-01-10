using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.Queries.Authentication;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _Booking : RealmDatabase
    {
        [TestMethod]
        public void Mutation_AddBookingToBill()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 200,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                @"/_GraphQL/Booking/mutation.addBookingToBill.schema.json",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                        bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                        room = new { id = 200 },
                        listOfPatrons = new[]
                        {
                            new { id = 1 }
                        }
                    },
                    bill = new
                    {
                        id = 1
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_AddBookingToBill_InvalidBill()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 201,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Mã hóa đơn không tồn tại",
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                        bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                        room = new { id = 201 },
                        listOfPatrons = new[]
                        {
                            new { id = 1 }
                        }
                    },
                    bill = new
                    {
                        id = 11
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_AddBookingToBill_InvalidDate()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Ngày check-in, check-out dự kiến không hợp lệ",
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = DateTimeOffset.Now.AddDays(5),
                        bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                        room = new { id = 1 },
                        listOfPatrons = new[]
                        {
                            new { id = 1 }
                        }
                    },
                    bill = new
                    {
                        id = 1
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_AddBookingToBill_InvalidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã phòng không tồn tại",
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                        bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                        room = new { id = 100 },
                        listOfPatrons = new[]
                        {
                            new { id = 1 }
                        }
                    },
                    bill = new
                    {
                        id = 1
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_AddBookingToBill_InvalidRoom_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 202,
                IsActive = false,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Phòng có Id: 202 đã ngưng hoạt động",
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                        bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                        room = new { id = 202 },
                        listOfPatrons = new[]
                        {
                            new { id = 1 }
                        }
                    },
                    bill = new
                    {
                        id = 1
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_AddBookingToBill_InvalidRoom_Empty()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Phòng đã được đặt hoặc đang được sử dụng",
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = DateTimeOffset.Now.AddDays(1),
                        bookCheckOutTime = DateTimeOffset.Now.AddDays(2),
                        room = new { id = 1 },
                        listOfPatrons = new[]
                        {
                            new { id = 1 }
                        }
                    },
                    bill = new
                    {
                        id = 1
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Room
                {
                    Id = 101,
                    IsActive = false,
                    Name = "Tên phòng",
                    IsClean = true,
                    Floor = FloorBusiness.Get(1),
                    RoomKind = RoomKindBusiness.Get(1)
                });
                realm.Add(new Booking
                {
                    Id = 10,
                    Status = BookingStatusEnum.Booked,
                    EmployeeBooking = EmployeeDataAccess.Get("admin"),
                    BookCheckInTime = DateTimeOffset.Now.AddDays(-1),
                    BookCheckOutTime = DateTimeOffset.Now.AddDays(1),
                    EmployeeCheckIn = null,
                    EmployeeCheckOut = null,
                    Bill = BillDataAccess.Get(1),
                    Room = RoomDataAccess.Get(101)
                });
            }).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                @"/_GraphQL/Booking/mutation.checkIn.schema.json",
                new { id = 10 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn_InvalidBookingStatus()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 11,
                Status = BookingStatusEnum.CheckedIn,
                EmployeeBooking = EmployeeDataAccess.Get("admin"),
                EmployeeCheckIn = null,
                EmployeeCheckOut = null,
                Bill = BillDataAccess.Get(1),
                Room = RoomDataAccess.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Phòng đã được check-in, không thể check-in lại",
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                new { id = 11 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã Booking không tồn tại",
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                new { id = 100 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckOut()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 20,
                Status = BookingStatusEnum.CheckedIn,
                EmployeeBooking = EmployeeDataAccess.Get("admin"),
                EmployeeCheckIn = EmployeeDataAccess.Get("admin"),
                EmployeeCheckOut = EmployeeDataAccess.Get("admin"),
                RealCheckInTime = DateTimeOffset.Now.AddDays(-1),
                Bill = BillDataAccess.Get(1),
                Room = RoomDataAccess.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                @"/_GraphQL/Booking/mutation.checkOut.schema.json",
                new { id = 20 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckOut_InvalidBookingStatus()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 21,
                Status = BookingStatusEnum.Booked,
                EmployeeBooking = EmployeeDataAccess.Get("admin"),
                EmployeeCheckIn = EmployeeDataAccess.Get("admin"),
                EmployeeCheckOut = EmployeeDataAccess.Get("admin"),
                RealCheckInTime = DateTimeOffset.Now.AddDays(-1),
                Bill = BillDataAccess.Get(1),
                Room = RoomDataAccess.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Booking chưa check-in, không thể check-out",
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                new { id = 21 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckOut_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã Booking không tồn tại",
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                new { id = 100 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckBookingPrice()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkBookingPrice.gql",
                @"/_GraphQL/Booking/mutation.checkBookingPrice.schema.json",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = "11-1-2019",
                        bookCheckOutTime = "11-3-2019",
                        room = new
                        {
                            id = 1
                        },
                        listOfPatrons = new[]
                        {
                            new
                            {
                                id = 1
                            }
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Query_Booking()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/query.booking.gql",
                @"/_GraphQL/Booking/query.booking.schema.json",
                new { id = 1 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Query_Bookings()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/query.bookings.gql",
                @"/_GraphQL/Booking/query.bookings.schema.json",
                null,
                p => p.PermissionManageRentingRoom = true
            );
        }
    }
}
