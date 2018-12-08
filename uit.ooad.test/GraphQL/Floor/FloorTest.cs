using System;
using System.IO;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using uit.ooad.GraphQLHelper;
using uit.ooad.Queries.Authentication;
using uit.ooad.Schemas;
using uit.ooad.test.Helper;

namespace uit.ooad.test.GraphQL.Floor
{
    [TestClass]
    public class FloorTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetListFloor()
        {
            bool isValid = SchemaHelper.Execute(
                @"/GraphQL/Floor/query.floors.gql",
                @"/GraphQL/Floor/query.floors.schema.json"
            );

            Assert.IsTrue(isValid, "floors fail");
        }
    }
}
