using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
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
                p => p.PermissionCreateOrUpdateRoomKind = true
            );
        }
    }
}