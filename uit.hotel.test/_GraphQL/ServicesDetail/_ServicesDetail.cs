using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _ServicesDetail : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.schema.json",
                new
                {
                    input = new
                    {
                        number = 1,
                        service = new
                        {
                            id = 1
                        },
                        booking = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateServicesDetail_InvalidBooking()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã booking không tồn tại",
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.gql",
                new
                {
                    input = new
                    {
                        number = 1,
                        service = new
                        {
                            id = 1
                        },
                        booking = new
                        {
                            id = 100
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateServicesDetail_InvalidService()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã dịch vụ không tồn tại",
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.gql",
                new
                {
                    input = new
                    {
                        number = 1,
                        service = new
                        {
                            id = 100
                        },
                        booking = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_CreateServicesDetail_InvalidService_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Service
            {
                Id = 101,
                IsActive = false,
                Name = "Tên dịch vụ",
                Unit = "Đơn vị"
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Dịch vụ 101 đã ngừng cung cấp",
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.gql",
                new
                {
                    input = new
                    {
                        number = 1,
                        service = new
                        {
                            id = 101
                        },
                        booking = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteServicesDetail()
        {
            Database.WriteAsync(realm => realm.Add(new ServicesDetail
            {
                Id = 10,
                Booking = BookingBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.schema.json",
                new { id = 10 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteServicesDetail_InvalidBooking_Status()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Booking
                {
                    Id = 200,
                    Status = (int)Booking.StatusEnum.CheckedOut,
                    EmployeeBooking = EmployeeDataAccess.Get("admin"),
                    EmployeeCheckIn = EmployeeDataAccess.Get("admin"),
                    EmployeeCheckOut = EmployeeDataAccess.Get("admin"),
                    Bill = BillDataAccess.Get(1),
                    Room = RoomDataAccess.Get(1)
                });
                realm.Add(new ServicesDetail
                {
                    Id = 11,
                    Booking = BookingBusiness.Get(1),
                    Service = ServiceBusiness.Get(200),
                    Number = 10
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Phòng đã check-out. Không thể cập nhật/xóa chi tiết dịch vụ",
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.gql",
                new { id = 11 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteServicesDetail_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã chi tiết dịch vụ không tồn tại",
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.gql",
                new { id = 100 },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.schema.json",
                new
                {
                    input = new
                    {
                        id = 2,
                        number = 2,
                        service = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateServicesDetail_InvalidService()
        {
            Database.WriteAsync(realm => realm.Add(new ServicesDetail
            {
                Id = 20,
                Booking = BookingBusiness.Get(1),
                Service = ServiceBusiness.Get(1),
                Number = 10
            })).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Mã dịch vụ không tồn tại",
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.gql",
                new
                {
                    input = new
                    {
                        id = 20,
                        number = 2,
                        service = new
                        {
                            id = 100
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateServicesDetail_InvalidService_InActive()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Service
                {
                    Id = 202,
                    IsActive = false,
                    Name = "Tên dịch vụ",
                    Unit = "Đơn vị"
                });
                realm.Add(new ServicesDetail
                {
                    Id = 21,
                    Booking = BookingBusiness.Get(1),
                    Service = ServiceBusiness.Get(1),
                    Number = 10
                });
            }).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Dịch vụ 202 đã ngừng cung cấp",
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.gql",
                new
                {
                    input = new
                    {
                        id = 21,
                        number = 2,
                        service = new
                        {
                            id = 202
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateServicesDetail_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã chi tiết dịch vụ không tồn tại",
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        number = 2,
                        service = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageRentingRoom = true
            );
        }

        [TestMethod]
        public void Query_ServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/query.servicesDetail.gql",
                @"/_GraphQL/ServicesDetail/query.servicesDetail.schema.json",
                new { id = 1 },
                p => p.PermissionGetService = true
            );
        }

        [TestMethod]
        public void Query_ServicesDetails()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/query.servicesDetails.gql",
                @"/_GraphQL/ServicesDetail/query.servicesDetails.schema.json",
                null,
                p => p.PermissionGetService = true
            );
        }
    }
}
