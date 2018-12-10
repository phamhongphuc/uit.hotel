using System;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

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
                Password = "12345678",
                PhoneNumber = "+84 0123456789",
                Position = PositionBusiness.Get(1),
                StartingDate = DateTime.Now
            });
        }

        private static void AddService()
        {
            ServiceBusiness.Add(new Service
            {
                Id = 1,
                Name = "Tên dịch vụ",
                UnitRate = 30000,
                Unit = "Đơn vị đo"
            });
        }

        private static void AddVolatilityRate()
        {
            VolatilityRateBusiness.Add(new VolatilityRate
            {
                Id = 1,
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
                Id = 1,
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
                Identification = "Id khách hàng",
                Name = "Tên khách hàng",
                Email = "Email khách hàng",
                Gender = true,
                Birthdate = DateTime.Now,
                PhoneNumber = 0123456,
                Nationality = "Quốc tịch",
                Domicile = "Nguyên quán",
                Residence = "Thường trú",
                Company = "Công ty",
                Note = "Ghi chú",
                PatronKind = PatronKindBusiness.Get(1)
            });
        }

        private static void AddPatronKind()
        {
            PatronKindBusiness.Add(new PatronKind
            {
                Id = 1,
                Name = "Tên loại khách hàng",
                Description = "Mô tả loại khách hàng"
            });
        }

        private static void AddRoom()
        {
            RoomBusiness.Add(new Room
            {
                Id = 1,
                Name = "Phòng 1",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            });
        }

        private static void AddRoomKind()
        {
            RoomKindBusiness.Add(new RoomKind
            {
                Id = 1,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                PriceByDate = 1
            });
        }

        private static void AddFloor()
        {
            FloorBusiness.Add(new Floor
            {
                Id = 1,
                Name = "Tầng 1"
            });
        }

        private static void AddBill()
        {
            BillBusiness.Add(new Bill
            {
                Id = "1",
                Time = DateTime.Now,
                Employee = EmployeeBusiness.Get(Constant.UserName),
                Patron = PatronBusiness.Get("Id khách hàng")
            });
        }
    }
}