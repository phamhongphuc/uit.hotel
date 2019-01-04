using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Room : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateRoom()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.createRoom.gql",
                @"/_GraphQL/Room/mutation.createRoom.schema.json",
                @"/_GraphQL/Room/mutation.createRoom.variable.json",
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoom()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 10,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.deleteRoom.gql",
                @"/_GraphQL/Room/mutation.deleteRoom.schema.json",
                @"/_GraphQL/Room/mutation.deleteRoom.variable.json",
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveRoom()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 20,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.setIsActiveRoom.gql",
                @"/_GraphQL/Room/mutation.setIsActiveRoom.schema.json",
                new { id = 20, isActive = true },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 30,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                @"/_GraphQL/Room/mutation.updateRoom.schema.json",
                @"/_GraphQL/Room/mutation.updateRoom.variable.json",
                p => p.PermissionManageMap = true
            );
        }
        [TestMethod]
        public void Query_Room()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/query.room.gql",
                @"/_GraphQL/Room/query.room.schema.json",
                @"/_GraphQL/Room/query.room.variable.json",
                p => p.PermissionGetMap = true
            );
        }

        [TestMethod]
        public void Query_Rooms()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/query.rooms.gql",
                @"/_GraphQL/Room/query.rooms.schema.json",
                null,
                p => p.PermissionGetMap = true
            );
        }
    }
}
