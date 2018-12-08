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

namespace uit.ooad.test.GraphQL.Room
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public void Rooms()
        {
            SchemaHelper.Execute(
                @"/GraphQL/Room/query.rooms.gql",
                @"/GraphQL/Room/query.rooms.schema.json"
            );
        }
    }
}
