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
    public class _HouseKeeping : RealmDatabase
    {
        [TestMethod]
        public void Mutation_AssignCleaningService()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 10,
                Status = (int)HouseKeeping.StatusEnum.Pending,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.gql",
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.schema.json",
                new { id = 10 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_AssignCleaningService_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã dọn phòng không tồn tại",
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.gql",
                new { id = 100 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_AssignCleaningService_InvalidStaus()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 11,
                Status = (int)HouseKeeping.StatusEnum.Cleaned,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Không thể nhận phòng này. Phòng đã hoặc đang được dọn",
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.gql",
                new { id = 11 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleaned()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 20,
                Status = (int)HouseKeeping.StatusEnum.Cleaning,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.gql",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.schema.json",
                new { id = 20 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleaned_InvalidEmployee()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Employee
                {
                    Id = "nhanvien_60",
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
                realm.Add(new HouseKeeping
                {
                    Id = 22,
                    Status = (int)HouseKeeping.StatusEnum.Cleaning,
                    Employee = EmployeeBusiness.Get("nhanvien_60"),
                    Booking = BookingBusiness.Get(1)
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Nhân viên không được phép xác nhận dọn",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.gql",
                new { id = 22 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleaned_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã dọn phòng không tồn tại",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.gql",
                new { id = 100 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleaned_InvalidStatus()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 21,
                Status = (int)HouseKeeping.StatusEnum.Pending,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Không thể xác nhận dọn phòng",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.gql",
                new { id = 21 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleaned_InvalidType()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 23,
                Type = (int)HouseKeeping.TypeEnum.ExpectedDeparture,
                Status = (int)HouseKeeping.StatusEnum.Cleaning,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Không thể sử dụng kiểu xác nhận này đối với phòng check-out",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.gql",
                new { id = 23 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleanedAndServices()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 30,
                Status = (int)HouseKeeping.StatusEnum.Cleaning,
                Type = (int)HouseKeeping.TypeEnum.ExpectedDeparture,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.gql",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.schema.json",
                new
                {
                    servicesDetails = new[]
                    {
                        new
                        {
                            number = 1,
                            service = new { id = 1 }
                        },
                        new
                        {
                            number = 2,
                            service = new { id = 1 }
                        }
                    },
                    houseKeepingId = 30
                },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleanedAndServices_InvalidEmployee()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Employee
                {
                    Id = "nhanvien_70",
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
                realm.Add(new HouseKeeping
                {
                    Id = 31,
                    Status = (int)HouseKeeping.StatusEnum.Cleaning,
                    Type = (int)HouseKeeping.TypeEnum.ExpectedDeparture,
                    Employee = EmployeeBusiness.Get("nhanvien_70"),
                    Booking = BookingBusiness.Get(1)
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Nhân viên không được phép xác nhận dọn",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.gql",
                new
                {
                    servicesDetails = new[]
                    {
                        new
                        {
                            number = 1,
                            service = new { id = 1 }
                        },
                        new
                        {
                            number = 2,
                            service = new { id = 1 }
                        }
                    },
                    houseKeepingId = 31
                },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleanedAndServices_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã dọn phòng không tồn tại",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.gql",
                new
                {
                    servicesDetails = new[]
                    {
                        new
                        {
                            number = 1,
                            service = new { id = 1 }
                        },
                        new
                        {
                            number = 2,
                            service = new { id = 1 }
                        }
                    },
                    houseKeepingId = 100
                },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleanedAndServices_InvalidService()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Service
                {
                    Id = 40,
                    IsActive = false,
                    Name = "Tên dịch vụ",
                    Unit = "Đơn vị"
                });
                realm.Add(new HouseKeeping
                {
                    Id = 32,
                    Status = (int)HouseKeeping.StatusEnum.Cleaning,
                    Type = (int)HouseKeeping.TypeEnum.ExpectedDeparture,
                    Employee = EmployeeBusiness.Get("admin"),
                    Booking = BookingBusiness.Get(1)
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Dịch vụ Tên dịch vụ đã ngừng cung cấp",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.gql",
                new
                {
                    servicesDetails = new[]
                    {
                        new
                        {
                            number = 1,
                            service = new { id = 1 }
                        },
                        new
                        {
                            number = 2,
                            service = new { id = 40 }
                        }
                    },
                    houseKeepingId = 32
                },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleanedAndServices_InvalidStatus()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 33,
                Status = (int)HouseKeeping.StatusEnum.Pending,
                Type = (int)HouseKeeping.TypeEnum.ExpectedDeparture,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Không thể xác nhận dọn phòng",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.gql",
                new
                {
                    servicesDetails = new[]
                    {
                        new
                        {
                            number = 1,
                            service = new { id = 1 }
                        },
                        new
                        {
                            number = 2,
                            service = new { id = 1 }
                        }
                    },
                    houseKeepingId = 33
                },
                p => p.PermissionCleaning = true
            );
        }


        [TestMethod]
        public void Mutation_ConfirmCleanedAndServices_InvalidType()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 34,
                Status = (int)HouseKeeping.StatusEnum.Cleaning,
                Type = (int)HouseKeeping.TypeEnum.ExpectedArrival,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Chỉ được sử dụng kiểu xác nhận này đối với phòng check-out",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.gql",
                new
                {
                    servicesDetails = new[]
                    {
                        new
                        {
                            number = 1,
                            service = new { id = 1 }
                        },
                        new
                        {
                            number = 2,
                            service = new { id = 1 }
                        }
                    },
                    houseKeepingId = 34
                },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Query_HouseKeeping()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 40,
                Status = (int)HouseKeeping.StatusEnum.Cleaning,
                Type = (int)HouseKeeping.TypeEnum.ExpectedDeparture,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/query.houseKeeping.gql",
                @"/_GraphQL/HouseKeeping/query.houseKeeping.schema.json",
                new { id = 40 }
            );
        }

        [TestMethod]
        public void Query_HouseKeepings()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/query.houseKeepings.gql",
                @"/_GraphQL/HouseKeeping/query.houseKeepings.schema.json"
            );
        }
    }
}
