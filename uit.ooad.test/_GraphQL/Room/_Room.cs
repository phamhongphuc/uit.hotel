using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Room
{
    [TestClass]
    public class _Room
    {
        [TestMethod]
        public void Rooms()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/query.rooms.gql",
                @"/_GraphQL/Room/query.rooms.schema.json",
                null,
                p => p.PermissionGetGroundPlan = true
            );
        }

        [TestMethod]
        public void Room()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/query.room.gql",
                @"/_GraphQL/Room/query.room.schema.json",
                @"/_GraphQL/Room/query.room.variable.json",
                p => p.PermissionGetGroundPlan = true
            );
        }

        [TestMethod]
        public void CreateRoom()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.createRoom.gql",
                @"/_GraphQL/Room/mutation.createRoom.schema.json",
                @"/_GraphQL/Room/mutation.createRoom.variable.json",
                p => p.PermissionUpdateGroundPlan = true
            );
        }

        [TestMethod]
        public void UpdateRoom()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                @"/_GraphQL/Room/mutation.updateRoom.schema.json",
                @"/_GraphQL/Room/mutation.updateRoom.variable.json",
                p => p.PermissionUpdateGroundPlan = true
            );
        }

        [TestMethod]
        public void DeleteRoom()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.deleteRoom.gql",
                @"/_GraphQL/Room/mutation.deleteRoom.schema.json",
                @"/_GraphQL/Room/mutation.deleteRoom.variable.json",
                p => p.PermissionUpdateGroundPlan = true
            );
        }

        [TestMethod]
        public void SetIsActiveRoom()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.setIsActiveRoom.gql",
                @"/_GraphQL/Room/mutation.setIsActiveRoom.schema.json",
                @"/_GraphQL/Room/mutation.setIsActiveRoom.variable.json",
                p => p.PermissionUpdateGroundPlan = true
            );
        }
    }
}
