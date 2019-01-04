using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _VolatilityRate : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateVolatilityRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/mutation.createVolatilityRate.gql",
                @"/_GraphQL/VolatilityRate/mutation.createVolatilityRate.schema.json",
                @"/_GraphQL/VolatilityRate/mutation.createVolatilityRate.variable.json",
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateVolatilityRate()
        {
            Database.WriteAsync(realm => realm.Add(new VolatilityRate
            {
                Id = 10,
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/mutation.updateVolatilityRate.gql",
                @"/_GraphQL/VolatilityRate/mutation.updateVolatilityRate.schema.json",
                @"/_GraphQL/VolatilityRate/mutation.updateVolatilityRate.variable.json",
                p => p.PermissionManageRate = true
            );
        }
        [TestMethod]
        public void Query_VolatilityRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/query.volatilityRate.gql",
                @"/_GraphQL/VolatilityRate/query.volatilityRate.schema.json",
                @"/_GraphQL/VolatilityRate/query.volatilityRate.variable.json",
                p => p.PermissionGetRate = true
            );
        }

        [TestMethod]
        public void Query_VolatilityRates()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/query.volatilityRates.gql",
                @"/_GraphQL/VolatilityRate/query.volatilityRates.schema.json",
                null,
                p => p.PermissionGetRate = true
            );
        }
    }
}
