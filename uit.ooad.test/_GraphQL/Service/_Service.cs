using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Service
{
    [TestClass]
    public class _Service
    {
        [TestMethod]
        public void Services()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Service/query.services.gql",
                @"/_GraphQL/Service/query.services.schema.json"
            );
        }
        [TestMethod]
        public void Service()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Service/query.service.gql",
                @"/_GraphQL/Service/query.service.schema.json",
                @"/_GraphQL/Service/query.service.variable.json"
            );
        }
        [TestMethod]
        public void CreateService()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Service/mutation.createService.gql",
                @"/_GraphQL/Service/mutation.createService.schema.json",
                @"/_GraphQL/Service/mutation.createService.variable.json",
                p => p.PermissionCreateService = true
            );
        }
    }
}
