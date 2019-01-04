using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.Queries.Helper;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Booking : RealmDatabase
    {
        [TestMethod]
        public void Mutation_AddBookingToBill()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                @"/_GraphQL/Booking/mutation.addBookingToBill.schema.json",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = DateTimeOffset.Now.AddDays(1).ToString("s"),
                        bookCheckOutTime = DateTimeOffset.Now.AddDays(2).ToString("s"),
                        room = new
                        {
                            id = 1,
                        },
                        listOfPatrons = new[]{
                            new { id = 1 },
                        },
                    },
                    billId = 1
                },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_AddBookingToBill_InvalidBill()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã hóa đơn không tồn tại",
                @"/_GraphQL/Booking/mutation.addBookingToBill.gql",
                new
                {
                    booking = new
                    {
                        bookCheckInTime = DateTimeOffset.Now.AddDays(1).ToString("s"),
                        bookCheckOutTime = DateTimeOffset.Now.AddDays(2).ToString("s"),
                        room = new
                        {
                            id = 1,
                        },
                        listOfPatrons = new[]{
                            new { id = 1 },
                        },
                    },
                    billId = 1
                },
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
                Room = RoomDataAccess.Get(1),
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
                Room = RoomDataAccess.Get(1),
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
                Room = RoomDataAccess.Get(1),
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
                Room = RoomDataAccess.Get(1),
            })).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Booking chưa thực hiện yêu cầu check-out",
                @"/_GraphQL/Booking/mutation.checkOut.gql",
                new { id = 21 },
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
                Room = RoomDataAccess.Get(1),
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
                Room = RoomDataAccess.Get(1),
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
