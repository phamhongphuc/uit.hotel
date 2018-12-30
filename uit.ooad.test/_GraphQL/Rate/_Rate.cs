using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Rate
{
    [TestClass]
    public class _Rate
    {
        [TestMethod]
        public void Rates()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/query.rates.gql",
                @"/_GraphQL/Rate/query.rates.schema.json",
                null,
                p => p.PermissionGetRate = true
            );
        }

        [TestMethod]
        public void Rate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/query.rate.gql",
                @"/_GraphQL/Rate/query.rate.schema.json",
                @"/_GraphQL/Rate/query.rate.variable.json",
                p => p.PermissionGetRate = true
            );
        }

        [TestMethod]
        public void CreateRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/mutation.createRate.gql",
                @"/_GraphQL/Rate/mutation.createRate.schema.json",
                @"/_GraphQL/Rate/mutation.createRate.variable.json",
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void DeleteRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/mutation.deleteRate.gql",
                @"/_GraphQL/Rate/mutation.deleteRate.schema.json",
                @"/_GraphQL/Rate/mutation.deleteRate.variable.json",
                p => p.PermissionManageRate = true
            );
        }
    }
}
