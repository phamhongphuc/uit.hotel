using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._RoomKind
{
    [TestClass]
    public class _RoomKind
    {
        [TestMethod]
        public void RoomKinds()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/query.roomKinds.gql",
                @"/_GraphQL/RoomKind/query.roomKinds.schema.json"
            );
        }

        [TestMethod]
        public void RoomKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/query.roomKind.gql",
                @"/_GraphQL/RoomKind/query.roomKind.schema.json",
                @"/_GraphQL/RoomKind/query.roomKind.variable.json"
            );
        }

        [TestMethod]
        public void CreateRoomKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/mutation.createRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.createRoomKind.schema.json",
                @"/_GraphQL/RoomKind/mutation.createRoomKind.variable.json",
                p => p.PermissionManageRoomKind = true
            );
        }

        [TestMethod]
        public void SetIsActiveRoomKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.gql",
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.schema.json",
                @"/_GraphQL/RoomKind/mutation.setIsActiveRoomKind.variable.json",
                p => p.PermissionManageRoomKind = true
            );
        }
    }
}
