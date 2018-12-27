using System;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using System.Collections.Generic;

namespace uit.ooad.Queries.Helper
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
            AddCheckedInBill();
            AddRequestCheckOutBill();

            AddConfirmCleaned();
            AddConfirmCleanedAndServices();
            AddReceipt();
        }

        private static void ResetDatebase()
        {
            Database.WriteAsync(realm => realm.RemoveAll());
        }

        private static void AddPosition()
        {
            PositionBusiness.Add(new Position()
            {
                Name = "Quản trị viên",
                PermissionUpdateGroundPlan = true,
                PermissionManagePatrons = true,
                PermissionManagePatronKinds = true,
                PermissionHandleBills = true,
                PermissionGetRooms = true,
                PermissionManageHiringRooms = true,
                PermissionGetHouseKeepings = true,
                PermissionCreateBill = true,
                PermissionCreateBooking = true,
                PermissionCreateOrUpdateEmployee = true,
                PermissionCleaning = true,
                PermissionCreateOrUpdatePatron = true,
                PermissionCreatePosition = true,
                PermissionCreateOrUpdateRate = true,
                PermissionCreateReceipt = true,
                PermissionCreateOrUpdateRoomKind = true,
                PermissionCreateOrUpdateService = true,
                PermissionCreateServicesDetail = true,
                PermissionCreateOrUpdateVolatilityRate = true
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
                    BookCheckInTime = DateTime.Now,
                    BookCheckOutTime = DateTime.Now,
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

        private static void AddCheckedInBill()
        {
            AddBill();
            BookingBusiness.CheckIn(EmployeeBusiness.Get(Constant.UserName), 2);
        }

        private static void AddRequestCheckOutBill()
        {
            AddBill();
            BookingBusiness.CheckIn(EmployeeBusiness.Get(Constant.UserName), 3);
            BookingBusiness.RequestCheckOut(EmployeeBusiness.Get(Constant.UserName), 3);
            HouseKeepingBusiness.AssignCleaningService(EmployeeBusiness.Get(Constant.UserName), 3);
        }
        private static void AddConfirmCleaned()
        {
            HouseKeepingBusiness.AssignCleaningService(EmployeeBusiness.Get(Constant.UserName), 2);
        }
        private static void AddConfirmCleanedAndServices()
        {
            AddBill();
            BookingBusiness.CheckIn(EmployeeBusiness.Get(Constant.UserName), 4);
            BookingBusiness.RequestCheckOut(EmployeeBusiness.Get(Constant.UserName), 4);
            HouseKeepingBusiness.AssignCleaningService(EmployeeBusiness.Get(Constant.UserName), 5);
            HouseKeepingBusiness.ConfirmCleanedAndServices(EmployeeBusiness.Get(Constant.UserName),
            new List<ServicesDetail>
            {
                new ServicesDetail
                {
                    Number = 1,
                    Service = new Service{
                        Id = 1
                    }
                },
                new ServicesDetail
                {
                    Number = 1,
                    Service = new Service{
                        Id = 1
                    }
                }
            }, 5);
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