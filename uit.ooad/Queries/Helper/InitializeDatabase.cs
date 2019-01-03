using System;
using System.Collections.Generic;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Queries.Helper
{
    public class InitializeDatabase : RealmDatabase
    {
        public static void InitializeDatabaseObject()
        {
            ResetDatebase();

            AddPosition();
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
            PositionBusiness.Add(new Position
            {
                Name = "Quản trị viên",
                PermissionCleaning = true,
                PermissionGetAccountingVoucher = true,
                PermissionGetHouseKeeping = true,
                PermissionGetMap = true,
                PermissionGetPatron = true,
                PermissionGetPosition = true,
                PermissionGetRate = true,
                PermissionGetService = true,
                PermissionManageEmployee = true,
                PermissionManageHiringRoom = true,
                PermissionManagePatron = true,
                PermissionManagePatronKind = true,
                PermissionManagePosition = true,
                PermissionManageRate = true,
                PermissionManageRoomKind = true,
                PermissionManageService = true,
                PermissionManageMap = true,
            });
        }

        private static void AddEmployee()
        {
            EmployeeBusiness.Add(new Employee
            {
                Id = Constant.UserName,
                Address = "Địa chỉ",
                Birthdate = DateTimeOffset.Now,
                Email = "email@gmail.com",
                Gender = true,
                Name = "Quản trị viên",
                IdentityCard = "123456789",
                Password = "12345678",
                PhoneNumber = "+84 0123456789",
                Position = PositionBusiness.Get(1),
                IsActive = true,
                StartingDate = DateTimeOffset.Now
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
            VolatilityRateBusiness.Add(EmployeeBusiness.Get(Constant.UserName), new VolatilityRate
            {
                DayRate = 10,
                NightRate = 5,
                WeekRate = 50,
                MonthRate = 200,
                LateCheckOutFee = 2,
                EarlyCheckInFee = 2,
                EffectiveStartDate = DateTimeOffset.Now,
                EffectiveEndDate = DateTimeOffset.Now,
                EffectiveOnMonday = true,
                EffectiveOnTuesday = true,
                EffectiveOnWednesday = true,
                EffectiveOnThursday = true,
                RoomKind = RoomKindBusiness.Get(1)
            });
        }

        private static void AddRate()
        {
            RateBusiness.Add(EmployeeBusiness.Get(Constant.UserName), new Rate
            {
                DayRate = 100000,
                NightRate = 60000,
                WeekRate = 500000,
                MonthRate = 2000000,
                LateCheckOutFee = 10000,
                EarlyCheckInFee = 10000,
                EffectiveStartDate = DateTimeOffset.MinValue,
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
                Birthdate = DateTimeOffset.Now,
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
                Name = "101",
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
                IsActive = true
            });
        }

        private static void AddFloor()
        {
            FloorBusiness.Add(new Floor
            {
                Name = "1",
                IsActive = true
            });
        }

        private static void AddBill()
        {
            BillBusiness.Book(
                EmployeeBusiness.Get(Constant.UserName),
                new Bill
                {
                    Time = DateTimeOffset.Now,
                    Patron = PatronBusiness.Get(1)
                },
                new List<Booking>
                {
                    new Booking
                    {
                        BookCheckInTime = DateTimeOffset.Now,
                        BookCheckOutTime = DateTimeOffset.Now,
                        Room = RoomBusiness.Get(1),
                        ListOfPatrons = new List<Patron>
                        {
                            new Patron
                            {
                                Id = 1
                            }
                        }
                    }
                }
            );
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
                                                                   Service = new Service
                                                                   {
                                                                       Id = 1
                                                                   }
                                                               },
                                                               new ServicesDetail
                                                               {
                                                                   Number = 1,
                                                                   Service = new Service
                                                                   {
                                                                       Id = 1
                                                                   }
                                                               }
                                                           }, 5);
        }

        private static void AddReceipt()
        {
            ReceiptBusiness.Add(EmployeeBusiness.Get(Constant.UserName), new Receipt
            {
                Money = 1,
                BankAccountNumber = "11111",
                TypeOfPayment = 1,
                Bill = BillBusiness.Get(1),
                Employee = EmployeeBusiness.Get(Constant.UserName)
            });
        }
    }
}
