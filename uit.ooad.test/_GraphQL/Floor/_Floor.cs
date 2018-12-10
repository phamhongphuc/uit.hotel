using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Floor
{
    [TestClass]
    public class _Floor
    {
        [TestMethod]
        public void Floors()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/query.floors.gql",
                @"/_GraphQL/Floor/query.floors.schema.json"
            );
        }

        [TestMethod]
        public void CreateFloor()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.createFloor.gql",
                @"/_GraphQL/Floor/mutation.createFloor.schema.json",
                @"/_GraphQL/Floor/mutation.createFloor.variable.json",
                p => p.PermissionCreateFloor = true
            );
        }
    }
}
