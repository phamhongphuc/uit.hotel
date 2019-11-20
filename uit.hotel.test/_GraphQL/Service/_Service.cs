using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _Service : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateService()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Service/mutation.createService.gql",
                @"/_GraphQL/Service/mutation.createService.schema.json",
                new
                {
                    input = new
                    {
                        name = "Tên dịch vụ 1",
                        unitPrice = 30000,
                        unit = "Đơn vị tính"
                    }
                },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteService()
        {
            Database.WriteAsync(realm => realm.Add(new Service
            {
                Id = 10,
                IsActive = true
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Service/mutation.deleteService.gql",
                @"/_GraphQL/Service/mutation.deleteService.schema.json",
                new { id = 10 },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteService_InvalidHasServicesDetail()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Dịch vụ này đã được sử dụng. Không thể cập nhật/xóa!",
                @"/_GraphQL/Service/mutation.deleteService.gql",
                new { id = 1 },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteService_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã dịch vụ không hợp lệ!",
                @"/_GraphQL/Service/mutation.deleteService.gql",
                new { id = 100 },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteService_InvalidId_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Service
            {
                Id = 11,
                IsActive = false,
                Name = "Tên dịch vụ 11",
                Unit = "Đơn vị"
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Dịch vụ 11 đã ngừng cung cấp. Không thể cập nhật/xóa!",
                @"/_GraphQL/Service/mutation.deleteService.gql",
                new { id = 11 },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveService()
        {
            Database.WriteAsync(realm => realm.Add(new Service
            {
                Id = 20,
                IsActive = true,
                Name = "Tên dịch vụ 20",
                Unit = "Đơn vị"
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Service/mutation.setIsActiveService.gql",
                @"/_GraphQL/Service/mutation.setIsActiveService.schema.json",
                new { id = 20, isActive = false },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveService_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã dịch vụ không hợp lệ!",
                @"/_GraphQL/Service/mutation.setIsActiveService.gql",
                new { id = 100, isActive = false },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateService()
        {
            Database.WriteAsync(realm => realm.Add(new Service
            {
                Id = 30,
                IsActive = true,
                Name = "Tên dịch vụ 30",
                Unit = "Đơn vị"
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Service/mutation.updateService.gql",
                @"/_GraphQL/Service/mutation.updateService.schema.json",
                new
                {
                    input = new
                    {
                        id = 30,
                        name = "Tên dịch vụ 30.1",
                        unitPrice = 30000,
                        unit = "Đơn vị tính"
                    }
                },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateService_InvalidHasServicesDetail()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Dịch vụ này đã được sử dụng. Không thể cập nhật/xóa!",
                @"/_GraphQL/Service/mutation.updateService.gql",
                new
                {
                    input = new
                    {
                        id = 1,
                        name = "Tên dịch vụ 1.1",
                        unitPrice = 30000,
                        unit = "Đơn vị tính"
                    }
                },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateService_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã dịch vụ không hợp lệ!",
                @"/_GraphQL/Service/mutation.updateService.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        name = "Tên dịch vụ 100",
                        unitPrice = 30000,
                        unit = "Đơn vị tính"
                    }
                },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateService_InvalidId_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Service
            {
                Id = 31,
                IsActive = true,
                Name = "Tên dịch vụ 31",
                Unit = "Đơn vị"
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Dịch vụ 31 đã ngừng cung cấp. Không thể cập nhật/xóa!",
                @"/_GraphQL/Service/mutation.updateService.gql",
                new
                {
                    input = new
                    {
                        id = 31,
                        name = "Tên dịch vụ 31.1",
                        unitPrice = 30000,
                        unit = "Đơn vị tính"
                    }
                },
                p => p.PermissionManageService = true
            );
        }

        [TestMethod]
        public void Query_Service()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Service/query.service.gql",
                @"/_GraphQL/Service/query.service.schema.json",
                new { id = 1 },
                p => p.PermissionGetService = true
            );
        }

        [TestMethod]
        public void Query_Services()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Service/query.services.gql",
                @"/_GraphQL/Service/query.services.schema.json",
                null,
                p => p.PermissionGetService = true
            );
        }
    }
}
