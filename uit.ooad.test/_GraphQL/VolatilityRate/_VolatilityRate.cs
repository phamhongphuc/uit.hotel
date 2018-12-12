using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._VolatilityRate
{
    [TestClass]
    public class _VolatilityRate
    {
        [TestMethod]
        public void VolatilityRates()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/query.volatilityRates.gql",
                @"/_GraphQL/VolatilityRate/query.volatilityRates.schema.json"
            );
        }
        [TestMethod]
        public void VolatilityRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/query.volatilityRate.gql",
                @"/_GraphQL/VolatilityRate/query.volatilityRate.schema.json"
            );
        }
    }
}
