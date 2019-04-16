using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _RoomKind : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateRoomKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/mutation.createRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.createRoomKind.schema.json",
                new
                {
                    input = new
                    {
                        name = "Loại 2",
                        numberOfBeds = 2,
                        amountOfPeople = 2
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 10,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = true
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/mutation.deleteRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.deleteRoomKind.schema.json",
                new { id = 10 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoomKind_InvalidHasRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng đã có phòng sử dụng, không thể cập nhật/xóa!",
                @"/_GraphQL/RoomKind/mutation.deleteRoomKind.gql",
                new { id = 1 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoomKind_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng có Id: 100 không tồn tại",
                @"/_GraphQL/RoomKind/mutation.deleteRoomKind.gql",
                new { id = 100 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoomKind_Invalid_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 11,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = true
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng có Id: 11 đã ngừng cung cấp. Không thể cập nhật/xóa!",
                @"/_GraphQL/RoomKind/mutation.deleteRoomKind.gql",
                new { id = 11 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 20,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = true
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.schema.json",
                new { id = 20, isActive = false },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveRoomKind_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng có Id: 100 không hợp lệ!",
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.gql",
                new { id = 100, isActive = false },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 30,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = true
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/mutation.updateRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.updateRoomKind.schema.json",
                new
                {
                    input = new
                    {
                        id = 30,
                        name = "Loại 2",
                        numberOfBeds = 2,
                        amountOfPeople = 2
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoomKind_InvalidHasRoom()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng đã có phòng sử dụng, không thể cập nhật/xóa!",
                @"/_GraphQL/RoomKind/mutation.updateRoomKind.gql",
                new
                {
                    input = new
                    {
                        id = 1,
                        name = "Loại 2",
                        numberOfBeds = 2,
                        amountOfPeople = 2
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoomKind_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng có Id: 100 không tồn tại",
                @"/_GraphQL/RoomKind/mutation.updateRoomKind.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        name = "Loại 2",
                        numberOfBeds = 2,
                        amountOfPeople = 2
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoomKind_InvalidId_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 33,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = false
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng có Id: 33 đã ngừng cung cấp. Không thể cập nhật/xóa!",
                @"/_GraphQL/RoomKind/mutation.updateRoomKind.gql",
                new
                {
                    input = new
                    {
                        id = 33,
                        name = "Loại 2",
                        numberOfBeds = 2,
                        amountOfPeople = 2
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Query_RoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 40,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = true
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/query.roomKind.gql",
                @"/_GraphQL/RoomKind/query.roomKind.schema.json",
                new { id = 40 },
                p => p.PermissionGetMap = true
            );
        }

        [TestMethod]
        public void Query_RoomKinds()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/query.roomKinds.gql",
                @"/_GraphQL/RoomKind/query.roomKinds.schema.json",
                null,
                p => p.PermissionGetMap = true
            );
        }
    }
}
