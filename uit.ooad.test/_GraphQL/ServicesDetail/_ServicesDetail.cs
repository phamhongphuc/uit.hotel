using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _ServicesDetail
    {
        [TestMethod]
        public void ServicesDetails()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/query.servicesDetails.gql",
                @"/_GraphQL/ServicesDetail/query.servicesDetails.schema.json",
                null,
                p => p.PermissionGetService = true
            );
        }

        [TestMethod]
        public void ServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/query.servicesDetail.gql",
                @"/_GraphQL/ServicesDetail/query.servicesDetail.schema.json",
                @"/_GraphQL/ServicesDetail/query.servicesDetail.variable.json",
                p => p.PermissionGetService = true
            );
        }

        [TestMethod]
        public void CreateServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.schema.json",
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.variable.json",
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void UpdateServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.schema.json",
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.variable.json",
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void DeleteServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.schema.json",
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.variable.json",
                p => p.PermissionCleaning = true
            );
        }
    }
}
