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
                    bill = new {
                        id = 1
                    }
                },
                p => p.PermissionManageHiringRoom = true
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
                    bill = new {
                        id = 1
                    }                },
                p => p.PermissionManageHiringRoom = true
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
                    bill = new {
                        id = 1
                    }                },
                p => p.PermissionManageHiringRoom = true
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
                    bill = new {
                        id = 1
                    }                },
                p => p.PermissionManageHiringRoom = true
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
                    bill = new {
                        id = 1
                    }                },
                p => p.PermissionManageHiringRoom = true
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
                    bill = new {
                        id = 1
                    }                },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 10,
                Status = (int)Booking.StatusEnum.Booked,
                EmployeeBooking = EmployeeDataAccess.Get("admin"),
                EmployeeCheckIn = null,
                EmployeeCheckOut = null,
                Bill = BillDataAccess.Get(1),
                Room = RoomDataAccess.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                @"/_GraphQL/Booking/mutation.checkIn.schema.json",
                new { id = 10 },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn_InvalidBookingStatus()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 11,
                Status = (int)Booking.StatusEnum.CheckedIn,
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
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckIn_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã Booking không tồn tại",
                @"/_GraphQL/Booking/mutation.checkIn.gql",
                new { id = 100 },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckOut()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 20,
                Status = (int)Booking.StatusEnum.RequestedCheckOut,
                EmployeeBooking = EmployeeDataAccess.Get("admin"),
                EmployeeCheckIn = EmployeeDataAccess.Get("admin"),
                EmployeeCheckOut = EmployeeDataAccess.Get("admin"),
                Bill = BillDataAccess.Get(1),
                Room = RoomDataAccess.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                @"/_GraphQL/Booking/mutation.checkOut.schema.json",
                new { id = 20 },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckOut_InvalidBookingStatus()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 21,
                Status = (int)Booking.StatusEnum.CheckedIn,
                EmployeeBooking = EmployeeDataAccess.Get("admin"),
                EmployeeCheckIn = EmployeeDataAccess.Get("admin"),
                EmployeeCheckOut = EmployeeDataAccess.Get("admin"),
                Bill = BillDataAccess.Get(1),
                Room = RoomDataAccess.Get(1)
            })).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Booking chưa thực hiện yêu cầu check-out",
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                new { id = 21 },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CheckOut_InvalidEmployee()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Employee
                {
                    Id = "nhanvien_1",
                    Address = "Địa chỉ",
                    IsActive = true,
                    Birthdate = DateTimeOffset.Now,
                    Email = "email@gmail.com",
                    Gender = true,
                    Name = "Quản trị viên",
                    IdentityCard = "123456789",
                    Password = CryptoHelper.Encrypt("12345678"),
                    PhoneNumber = "+84 0123456789",
                    Position = PositionBusiness.Get(1),
                    StartingDate = DateTimeOffset.Now
                });
                realm.Add(new Booking
                {
                    Id = 22,
                    Status = (int)Booking.StatusEnum.RequestedCheckOut,
                    EmployeeBooking = EmployeeDataAccess.Get("admin"),
                    EmployeeCheckIn = EmployeeDataAccess.Get("admin"),
                    EmployeeCheckOut = EmployeeDataAccess.Get("nhanvien_1"),
                    Bill = BillDataAccess.Get(1),
                    Room = RoomDataAccess.Get(1)
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Nhân viên không được phép check-out",
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                new { id = 22 },
                p => p.PermissionManageHiringRoom = true
            );
        }
        
        [TestMethod]
        public void Mutation_CheckOut_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã Booking không tồn tại",
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                new { id = 100 },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_RequestCheckOut()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 30,
                Status = (int)Booking.StatusEnum.CheckedIn,
                EmployeeBooking = EmployeeDataAccess.Get("admin"),
                EmployeeCheckIn = EmployeeDataAccess.Get("admin"),
                EmployeeCheckOut = EmployeeDataAccess.Get("admin"),
                Bill = BillDataAccess.Get(1),
                Room = RoomDataAccess.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.requestCheckOut.gql",
                @"/_GraphQL/Booking/mutation.requestCheckOut.schema.json",
                new { id = 30 },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_RequestCheckOut_InvalidBookingStatus()
        {
            Database.WriteAsync(realm => realm.Add(new Booking
            {
                Id = 31,
                Status = (int)Booking.StatusEnum.CheckedOut,
                EmployeeBooking = EmployeeDataAccess.Get("admin"),
                EmployeeCheckIn = EmployeeDataAccess.Get("admin"),
                EmployeeCheckOut = EmployeeDataAccess.Get("admin"),
                Bill = BillDataAccess.Get(1),
                Room = RoomDataAccess.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Không thể yêu cầu trả phòng",
                @"/_GraphQL/Booking/mutation.requestCheckOut.gql",
                new { id = 31 },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_RequestCheckOut_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã Booking không tồn tại",
                @"/_GraphQL/Booking/mutation.requestCheckOut.gql",
                new { id = 100 },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Query_Booking()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/query.booking.gql",
                @"/_GraphQL/Booking/query.booking.schema.json",
                new { id = 1 },
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
