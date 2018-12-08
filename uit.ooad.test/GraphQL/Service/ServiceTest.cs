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

namespace uit.ooad.test.GraphQL.Service
{
    [TestClass]
    public class ServiceTest
    {
        public ServiceTest()
        {
            ServiceBusiness.Add(new Models.Service()
            {
                Id = 1,
                Name = "Tên dịch vụ",
                UnitRate = 30000,
                Unit = "Đơn vị đo"
            });
        }
        [TestMethod]
        public void Services()
        {
            SchemaHelper.Execute(
                @"/GraphQL/Service/query.services.gql",
                @"/GraphQL/Service/query.services.schema.json"
            );
        }
    }
}
