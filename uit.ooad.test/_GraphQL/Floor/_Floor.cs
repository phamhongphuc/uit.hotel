using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Floor : RealmDatabase
    {

        [TestMethod]
        public void Mutation_CreateFloor()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.createFloor.gql",
                @"/_GraphQL/Floor/mutation.createFloor.schema.json",
                @"/_GraphQL/Floor/mutation.createFloor.variable.json",
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteFloor()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 10,
                Name = "Tầng tạo ra để xóa",
                IsActive = true,
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.deleteFloor.gql",
                @"/_GraphQL/Floor/mutation.deleteFloor.schema.json",
                @"/_GraphQL/Floor/mutation.deleteFloor.variable.json",
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveFloor()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 30,
                Name = "Tầng tạo ra để vô hiệu",
                IsActive = true,
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.gql",
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.schema.json",
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.variable.json",
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateFloor()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 40,
                Name = "Tầng tạo ra để vô hiệu",
                IsActive = true,
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.updateFloor.gql",
                @"/_GraphQL/Floor/mutation.updateFloor.schema.json",
                @"/_GraphQL/Floor/mutation.updateFloor.variable.json",
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Query_Floors()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/query.floors.gql",
                @"/_GraphQL/Floor/query.floors.schema.json",
                null,
                p => p.PermissionGetMap = true
            );
        }

        [TestMethod]
        public void Query_Floor()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 20,
                Name = "Tầng tạo ra để gọi",
                IsActive = true,
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/query.floor.gql",
                @"/_GraphQL/Floor/query.floor.schema.json",
                @"/_GraphQL/Floor/query.floor.variable.json",
                p => p.PermissionGetMap = true
            );
        }

        [TestMethod]
        public void Query_Floor_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng có Id: 100 không hợp lệ!",
                @"/_GraphQL/Floor/query.floor.gql",
                @"/_GraphQL/Floor/query.floor.variable.invalid_id.json",
                p => p.PermissionGetMap = true
            );
        }
    }
}
