using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
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
                @"/_GraphQL/Position/query.positions.schema.json"
            );
        }
        [TestMethod]
        public void Position()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/query.position.gql",
                @"/_GraphQL/Position/query.position.schema.json"
            );
        }
        [TestMethod]
        public void CreatePosition()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.createPosition.gql",
                @"/_GraphQL/Position/mutation.createPosition.schema.json",
                @"/_GraphQL/Position/mutation.createPosition.variable.json",
                p => p.PermissionCreatePosition = true
            );
        }
    }
}
