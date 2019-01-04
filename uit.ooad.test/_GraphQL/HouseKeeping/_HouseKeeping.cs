using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
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
        public void AssignCleaningService()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.gql",
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.schema.json",
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.variable.json",
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void ConfirmCleaned()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.gql",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.schema.json",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.variable.json",
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void ConfirmCleanedAndServices()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.gql",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.schema.json",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.variable.json",
                p => p.PermissionCleaning = true
            );
        }
    }
}
