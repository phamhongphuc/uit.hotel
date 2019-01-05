using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
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
        public void Mutation_SetIsActiveRoomKind()
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
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.schema.json",
                new { id = 10, isActive = false },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Query_RoomKind()
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
                @"/_GraphQL/RoomKind/query.roomKind.gql",
                @"/_GraphQL/RoomKind/query.roomKind.schema.json",
                new { id = 20 },
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
