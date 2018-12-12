using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
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
                @"/_GraphQL/Rate/query.rates.schema.json"
            );
        }
        [TestMethod]
        public void Rate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/query.rate.gql",
                @"/_GraphQL/Rate/query.rate.schema.json"
            );
        }
    }
}
