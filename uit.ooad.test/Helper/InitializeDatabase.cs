using System;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using System.Collections.Generic;

namespace uit.ooad.test.Helper
{
    public class InitializeDatabase : RealmDatabase
    {
        public static void InitializeDatabaseObject()
        {
            ResetDatebase();

            AddPosition();
            AddEmployee();

            AddFloor();

            AddRoomKind();
            AddRoom();

            AddPatronKind();
            AddPatron();
            AddRate();
            AddVolatilityRate();
            AddService();
            AddBill();
            // AddBooking();
            AddHouseKeeping();
            AddReceipt();
            AddServicesDetail();
        }

        private static void ResetDatebase()
        {
            Database.WriteAsync(realm => realm.RemoveAll());
        }

        private static void AddPosition()
        {
            PositionBusiness.Add(new Position()
            {
                Id = 1,
                Name = "Chức vụ quản trị",
                // Không thêm các quyền vào trong này
            });
        }

        private static void AddEmployee()
        {
            EmployeeBusiness.Add(new Employee()
            {
                Id = Constant.UserName,
                Address = "Địa chỉ",
                Birthdate = DateTime.Now,
                Name = "Quản trị viên",
                IdentityCard = "123456789",
                Password = "12345678",
                PhoneNumber = "+84 0123456789",
                Position = PositionBusiness.Get(1),
                IsActive = true,
                StartingDate = DateTime.Now
            });
        }

        private static void AddService()
        {
            ServiceBusiness.Add(new Service
            {
                Name = "Tên dịch vụ",
                UnitRate = 30000,
                Unit = "Đơn vị đo",
                IsActive = true
            });
        }

        private static void AddServicesDetail()
        {
            ServicesDetailBusiness.Add(new ServicesDetail
            {
                Time = DateTime.Now,
                Number = 1,
                Booking = BookingBusiness.Get(1),
                Service = ServiceBusiness.Get(1)
            });
        }

        private static void AddVolatilityRate()
        {
            VolatilityRateBusiness.Add(new VolatilityRate
            {
                DayRate = 1,
                NightRate = 1,
                WeekRate = 1,
                MonthRate = 1,
                LateCheckOutFee = 1,
                EarlyCheckInFee = 1,
                EffectiveStartDate = DateTime.Now,
                EffectiveEndDate = DateTime.Now,
                EffectiveOnMonday = true,
                EffectiveOnTuesday = true,
                EffectiveOnWednesday = true,
                EffectiveOnThursday = true,
                CreateDate = DateTime.Now,
                RoomKind = RoomKindBusiness.Get(1)
            });
        }

        private static void AddRate()
        {
            RateBusiness.Add(new Rate
            {
                DayRate = 1,
                NightRate = 1,
                WeekRate = 1,
                MonthRate = 1,
                LateCheckOutFee = 1,
                EarlyCheckInFee = 1,
                EffectiveStartDate = DateTime.Now,
                CreateDate = DateTime.Now,
                RoomKind = RoomKindBusiness.Get(1)
            });
        }

        private static void AddPatron()
        {
            PatronBusiness.Add(new Patron
            {
                Identification = "123456789",
                Name = "Tên khách hàng",
                Email = "Email khách hàng",
                Gender = true,
                Birthdate = DateTime.Now,
                Nationality = "Quốc tịch",
                Domicile = "Nguyên quán",
                Residence = "Thường trú",
                Company = "Công ty",
                Note = "Ghi chú",
                PatronKind = PatronKindBusiness.Get(1),
                ListOfPhoneNumbers = new List<string>
                {
                    "12324234",
                    "1234"
                }
            });
        }

        private static void AddPatronKind()
        {
            PatronKindBusiness.Add(new PatronKind
            {
                Name = "Tên loại khách hàng",
                Description = "Mô tả loại khách hàng"
            });
        }

        private static void AddRoom()
        {
            RoomBusiness.Add(new Room
            {
                Name = "Phòng 1",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1),
                IsActive = true
            });
        }

        private static void AddRoomKind()
        {
            RoomKindBusiness.Add(new RoomKind
            {
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                PriceByDate = 1,
                IsActive = true
            });
        }

        private static void AddFloor()
        {
            FloorBusiness.Add(new Floor
            {
                Name = "Tầng 1",
                IsActive = true
            });
        }

        private static void AddBill()
        {
            BillBusiness.Book(EmployeeBusiness.Get(Constant.UserName), new Bill
            {
                Time = DateTime.Now,
                Patron = PatronBusiness.Get(1)
            },
            new List<Booking>
            {
                new Booking
                {
                    CheckInTime = DateTime.Now,
                    CheckOutTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    Status = 0,
                    Room = RoomBusiness.Get(1),
                    ListOfPatrons = new List<Patron>
                    {
                        new Patron{
                            Id = 1
                        }
                    }
                }
            });
        }

        // private static void AddBooking()
        // {
        //     BookingBusiness.Add(new Booking
        //     {
        //         Id = 1,
        //         CheckInTime = DateTime.Now,
        //         CheckOutTime = DateTime.Now,
        //         CreateTime = DateTime.Now,
        //         Status = 0,
        //         Bill = BillBusiness.Get(1),
        //         Room = RoomBusiness.Get(1),
        //         Employee = EmployeeBusiness.Get(Constant.UserName)
        //     });
        // }
        private static void AddHouseKeeping()
        {
            HouseKeepingBusiness.Add(new HouseKeeping
            {
                Type = 1,
                Booking = BookingBusiness.Get(1),
                Employee = EmployeeBusiness.Get(Constant.UserName)
            });
        }
        private static void AddReceipt()
        {
            ReceiptBusiness.Add(new Receipt
            {
                Time = DateTime.Now,
                Money = 1,
                BankAccountNumber = "11111",
                TypeOfPayment = 1,
                Bill = BillBusiness.Get(1),
                Employee = EmployeeBusiness.Get(Constant.UserName)
            });
        }
    }
}