using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _RoomKind
    {
        [TestMethod]
        public void Mutation_CreateRoomKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/mutation.createRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.createRoomKind.schema.json",
                @"/_GraphQL/RoomKind/mutation.createRoomKind.variable.json",
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveRoomKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.schema.json",
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.variable.json",
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Query_RoomKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/query.roomKind.gql",
                @"/_GraphQL/RoomKind/query.roomKind.schema.json",
                @"/_GraphQL/RoomKind/query.roomKind.variable.json",
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
