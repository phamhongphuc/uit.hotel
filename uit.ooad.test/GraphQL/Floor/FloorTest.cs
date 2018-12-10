using System;
using System.IO;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using uit.ooad.Businesses;
using uit.ooad.GraphQLHelper;
using uit.ooad.Queries.Authentication;
using uit.ooad.Schemas;
using uit.ooad.test.Helper;

namespace uit.ooad.test.GraphQL.Floor
{
    [TestClass]
    public class FloorTest
    {
        public FloorTest()
        {
            FloorBusiness.Add(new Models.Floor()
            {
                Id = 1,
                Name = "Tầng 10"
            });
        }

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Floors()
        {
            SchemaHelper.Execute(
                @"/GraphQL/Floor/query.floors.gql",
                @"/GraphQL/Floor/query.floors.schema.json"
            );
        }
    }
}
