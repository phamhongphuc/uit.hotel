using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
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
                new
                {
                    input = new
                    {
                        name = "Tầng 7"
                    }
                },
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
                IsActive = true
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.deleteFloor.gql",
                @"/_GraphQL/Floor/mutation.deleteFloor.schema.json",
                new { id = 10 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteFloor_InvalidFloor_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 11,
                Name = "Tầng tạo ra để xóa",
                IsActive = false
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Tầng 11 đã ngưng hoạt động. Không thể cập nhật/xóa!",
                @"/_GraphQL/Floor/mutation.deleteFloor.gql",
                new { id = 11 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteFloor_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng có Id: 100 không hợp lệ!",
                @"/_GraphQL/Floor/mutation.deleteFloor.gql",
                new { id = 100 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteFloor_InvalidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng đã có phòng. Không thể cập nhật/xóa!",
                @"/_GraphQL/Floor/mutation.deleteFloor.gql",
                new { id = 1 },
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
                IsActive = true
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.gql",
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.schema.json",
                new { id = 30, isActive = false },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveFloor_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng có Id: 100 không hợp lệ!",
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.gql",
                new { id = 100, isActive = false },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveFloor_InvalidRoomActive()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng này còn phòng đang hoạt động, không thể vô hiệu hóa",
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.gql",
                new { id = 1, isActive = false },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateFloor()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 40,
                Name = "Tầng tạo ra để cập nhật",
                IsActive = true
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.updateFloor.gql",
                @"/_GraphQL/Floor/mutation.updateFloor.schema.json",
                new
                {
                    input = new
                    {
                        id = 40,
                        name = "Tên tầng đã được cập nhật"
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateFloor_InvalidFloor_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 41,
                Name = "Tầng tạo ra để cập nhật",
                IsActive = false
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Tầng 41 đã ngưng hoạt động. Không thể cập nhật/xóa!",
                @"/_GraphQL/Floor/mutation.updateFloor.gql",
                new
                {
                    input = new
                    {
                        id = 41,
                        name = "Tên tầng đã được cập nhật"
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateFloor_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng có Id: 100 không hợp lệ!",
                @"/_GraphQL/Floor/mutation.updateFloor.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        name = "Tên tầng đã được cập nhật"
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateFloor_InvalidRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng đã có phòng. Không thể cập nhật/xóa!",
                @"/_GraphQL/Floor/mutation.updateFloor.gql",
                new
                {
                    input = new
                    {
                        id = 1,
                        name = "Tên tầng đã được cập nhật"
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Query_Floor()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 20,
                Name = "Tầng tạo ra để gọi",
                IsActive = true
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/query.floor.gql",
                @"/_GraphQL/Floor/query.floor.schema.json",
                new { id = 20 },
                p => p.PermissionGetMap = true
            );
        }

        [TestMethod]
        public void Query_Floor_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng có Id: 100 không hợp lệ!",
                @"/_GraphQL/Floor/query.floor.gql",
                new { id = 100 },
                p => p.PermissionGetMap = true
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
    }
}
