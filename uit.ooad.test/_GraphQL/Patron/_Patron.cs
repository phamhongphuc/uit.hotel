using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Patron
{
    [TestClass]
    public class _Patron
    {
        [TestMethod]
        public void Patrons()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Patron/query.patrons.gql",
                @"/_GraphQL/Patron/query.patrons.schema.json"
            );
        }
    }
}
