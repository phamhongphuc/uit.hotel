using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._HouseKeeping
{
    [TestClass]
    public class _HouseKeeping
    {
        [TestMethod]
        public void HouseKeepings()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/query.houseKeepings.gql",
                @"/_GraphQL/HouseKeeping/query.houseKeepings.schema.json"
            );
        }
        [TestMethod]
        public void HouseKeeping()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/query.houseKeeping.gql",
                @"/_GraphQL/HouseKeeping/query.houseKeeping.schema.json",
                @"/_GraphQL/HouseKeeping/query.houseKeeping.variable.json"
            );
        }
        [TestMethod]
        public void CreateHouseKeeping()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.createHouseKeeping.gql",
                @"/_GraphQL/HouseKeeping/mutation.createHouseKeeping.schema.json",
                @"/_GraphQL/HouseKeeping/mutation.createHouseKeeping.variable.json",
                p => p.PermissionAssignHouseKeeping = true
            );
        }
    }
}
