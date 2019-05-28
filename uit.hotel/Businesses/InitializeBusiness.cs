using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;

namespace uit.hotel.Businesses
{
    public static class InitializeBusiness
    {
        private static string ADMIN = "admin";

        public async static Task Initialize(Employee employee)
        {
            if (IsInitialized())
                throw new Exception("Cơ sở dữ liệu đã được khởi tạo trước đó");

            var position = await PositionBusiness.Add(new Position
            {
                Name = "admin",
                PermissionCleaning = true,
                PermissionGetAccountingVoucher = true,
                PermissionGetHouseKeeping = true,
                PermissionGetMap = true,
                PermissionGetPatron = true,
                PermissionGetRate = true,
                PermissionGetService = true,
                PermissionManageEmployee = true,
                PermissionManageRentingRoom = true,
                PermissionManageMap = true,
                PermissionManagePatron = true,
                PermissionManagePatronKind = true,
                PermissionManagePosition = true,
                PermissionManageRate = true,
                PermissionManageService = true,
                IsActive = true,
            });

            await EmployeeBusiness.Add(new Employee
            {
                Id = ADMIN,
                Password = employee.Password,
                Name = "admin",
                IdentityCard = "admin",
                PhoneNumber = "",
                Address = "",
                Email = employee.Email,
                Gender = true,
                Birthdate = new DateTimeOffset(),
                StartingDate = new DateTimeOffset(),
                Position = position,
                IsActive = true,
            });
        }

        public static bool IsInitialized()
        {
            var employees = EmployeeBusiness.Get();
            return employees.Count() != 0;
        }
    }
}
