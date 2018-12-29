using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                @"/_GraphQL/Floor/query.floors.schema.json",
                null,
                p => p.PermissionGetGroundPlan = true
            );
        }

        [TestMethod]
        public void Floor()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/query.floor.gql",
                @"/_GraphQL/Floor/query.floor.schema.json",
                @"/_GraphQL/Floor/query.floor.variable.json",
                p => p.PermissionGetGroundPlan = true
            );
        }

        [TestMethod]
        public void CreateFloor()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.createFloor.gql",
                @"/_GraphQL/Floor/mutation.createFloor.schema.json",
                @"/_GraphQL/Floor/mutation.createFloor.variable.json",
                p => p.PermissionUpdateGroundPlan = true
            );
        }

        [TestMethod]
        public void UpdateFloor()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.updateFloor.gql",
                @"/_GraphQL/Floor/mutation.updateFloor.schema.json",
                @"/_GraphQL/Floor/mutation.updateFloor.variable.json",
                p => p.PermissionUpdateGroundPlan = true
            );
        }

        [TestMethod]
        public void DeleteFloor()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.deleteFloor.gql",
                @"/_GraphQL/Floor/mutation.deleteFloor.schema.json",
                @"/_GraphQL/Floor/mutation.deleteFloor.variable.json",
                p => p.PermissionUpdateGroundPlan = true
            );
        }

        [TestMethod]
        public void SetIsActiveFloor()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.gql",
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.schema.json",
                @"/_GraphQL/Floor/mutation.setIsActiveFloor.variable.json",
                p => p.PermissionUpdateGroundPlan = true
            );
        }
    }
}
