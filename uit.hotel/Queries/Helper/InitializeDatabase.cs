using System;
using System.Collections.Generic;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.Queries.Authentication;

namespace uit.hotel.Queries.Helper
{
    public class InitializeDatabase : RealmDatabase
    {
        public static void InitializeDatabaseObject()
        {
            ResetDatebase();

            Database.WriteAsync(realm =>
            {
                var position = realm.Add(new Position
                {
                    Id = 1,
                    Name = "Quản trị viên",
                    IsActive = true,
                    PermissionCleaning = true,
                    PermissionGetAccountingVoucher = true,
                    PermissionGetMap = true,
                    PermissionGetPatron = true,
                    PermissionGetPrice = true,
                    PermissionGetService = true,
                    PermissionManageEmployee = true,
                    PermissionManageRentingRoom = true,
                    PermissionManagePatron = true,
                    PermissionManagePatronKind = true,
                    PermissionManagePosition = true,
                    PermissionManagePrice = true,
                    PermissionManageMap = true,
                    PermissionManageService = true
                });

                var admin = realm.Add(new Employee
                {
                    Id = "admin",
                    Address = "Địa chỉ",
                    IsActive = true,
                    Birthdate = DateTimeOffset.Now,
                    Email = "email@gmail.com",
                    Gender = true,
                    Name = "Quản trị viên",
                    IdentityCard = "123456789",
                    Password = CryptoHelper.EncryptPassword("12345678"),
                    PhoneNumber = "+84 0123456789",
                    Position = position,
                    StartingDate = DateTimeOffset.Now
                });

                realm.Add(new Employee
                {
                    Id = "inactive",
                    Address = "Địa chỉ",
                    IsActive = false,
                    Birthdate = DateTimeOffset.Now,
                    Email = "email@gmail.com",
                    Gender = true,
                    Name = "Quản trị viên",
                    IdentityCard = "123456789",
                    Password = CryptoHelper.EncryptPassword("12345678"),
                    PhoneNumber = "+84 0123456789",
                    Position = position,
                    StartingDate = DateTimeOffset.Now
                });

                var roomKind = realm.Add(new RoomKind
                {
                    Id = 1,
                    Name = "Tên loại phòng",
                    AmountOfPeople = 1,
                    NumberOfBeds = 1,
                    IsActive = true
                });

                var floor = realm.Add(new Floor
                {
                    Id = 1,
                    Name = "1",
                    IsActive = true
                });

                var room = realm.Add(new Room
                {
                    Id = 1,
                    Name = "101",
                    Floor = floor,
                    RoomKind = roomKind,
                    IsActive = true,
                    IsClean = true
                });

                var patronKind = realm.Add(new PatronKind
                {
                    Id = 1,
                    Name = "Tên loại khách hàng",
                    Description = "Mô tả loại khách hàng"
                });

                var patron = realm.Add(new Patron
                {
                    Id = 1,
                    Identification = "123456789",
                    Name = "Tên khách hàng",
                    Email = "Email khách hàng",
                    Gender = true,
                    Birthdate = DateTimeOffset.Now,
                    Nationality = "Quốc tịch",
                    Domicile = "Nguyên quán",
                    Residence = "Thường trú",
                    Company = "Công ty",
                    Note = "Ghi chú",
                    PatronKind = patronKind,
                    PhoneNumbers = "0123456789",
                });

                var bill = realm.Add(new Bill
                {
                    Id = 1,
                    Patron = patron,
                    Employee = admin
                });

                var booking = realm.Add(new Booking
                {
                    Id = 1,
                    Status = BookingStatusEnum.CheckedIn,
                    EmployeeBooking = admin,
                    EmployeeCheckIn = null,
                    EmployeeCheckOut = null,
                    Bill = bill,
                    Room = room
                });

                booking.Patrons.Add(patron);

                var service = realm.Add(new Service
                {
                    Id = 1,
                    Name = "Dịch vụ",
                    UnitPrice = 10000,
                    Unit = "Lần",
                    IsActive = true
                });

                var servicesDetail = realm.Add(new ServicesDetail
                {
                    Id = 1,
                    Number = 7,
                    Booking = booking,
                    Service = service
                });

                var Price = realm.Add(new Price
                {
                    Id = 1,
                    HourPrice = 30000,
                    DayPrice = 100000,
                    NightPrice = 80000,
                    WeekPrice = 600000,
                    MonthPrice = 2500000,
                    LateCheckOutFee = 30000,
                    EarlyCheckInFee = 30000,
                    EffectiveStartDate = DateTimeOffset.MinValue,
                    CreateDate = DateTimeOffset.Now.AddDays(-1),
                    Employee = admin,
                    RoomKind = roomKind
                });
            }).Wait();
        }

        private static void ResetDatebase()
        {
            Database.WriteAsync(realm => realm.RemoveAll());
        }
    }
}
