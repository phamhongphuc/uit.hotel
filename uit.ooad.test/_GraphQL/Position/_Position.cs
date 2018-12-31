using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Position
{
    [TestClass]
    public class _Position
    {
        [TestMethod]
        public void Positions()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/query.positions.gql",
                @"/_GraphQL/Position/query.positions.schema.json",
                null,
                p => p.PermissionGetPosition = true
            );
        }

        [TestMethod]
        public void Position()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/query.position.gql",
                @"/_GraphQL/Position/query.position.schema.json",
                @"/_GraphQL/Position/query.position.variable.json",
                p => p.PermissionGetPosition = true
            );
        }

        [TestMethod]
        public void CreatePosition()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.createPosition.gql",
                @"/_GraphQL/Position/mutation.createPosition.schema.json",
                @"/_GraphQL/Position/mutation.createPosition.variable.json",
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void UpdatePosition()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.updatePosition.gql",
                @"/_GraphQL/Position/mutation.updatePosition.schema.json",
                @"/_GraphQL/Position/mutation.updatePosition.variable.json",
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void DeletePosition()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.deletePosition.gql",
                @"/_GraphQL/Position/mutation.deletePosition.schema.json",
                @"/_GraphQL/Position/mutation.deletePosition.variable.json",
                p => p.PermissionManagePosition = true
            );
        }
    }
}
