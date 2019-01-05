using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
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
                        name = "Tên dịch vụ",
                        unitRate = 30000,
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
                IsActive = true,
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Service/mutation.deleteService.gql",
                @"/_GraphQL/Service/mutation.deleteService.schema.json",
                new { id = 10 },
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
                Name = "Tên dịch vụ",
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
        public void Mutation_UpdateService()
        {
            Database.WriteAsync(realm => realm.Add(new Service
            {
                Id = 30,
                IsActive = true,
                Name = "Tên dịch vụ",
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
                        name = "Tên dịch vụ",
                        unitRate = 30000,
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
