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
                new
                {
                    input = new
                    {
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 1
                        }
                    }
                },
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
                new
                {
                    input = new
                    {
                        id = 10,
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageRate = true
            );
        }
        [TestMethod]
        public void Query_VolatilityRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/query.volatilityRate.gql",
                @"/_GraphQL/VolatilityRate/query.volatilityRate.schema.json",
                new { id = 1 },
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
