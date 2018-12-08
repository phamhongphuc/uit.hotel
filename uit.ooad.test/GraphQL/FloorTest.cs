using System.IO;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using uit.ooad.GraphQLHelper;
using uit.ooad.Queries.Authentication;

namespace uit.ooad.test.GraphQL
{
    [TestClass]
    public class FloorTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetListFloor()
        {
            var configurationBuilder = new ConfigurationBuilder()
                                      .SetBasePath(Path.GetFullPath(@"..\..\..\..\uit.ooad"))
                                      .AddJsonFile("appsettings.json");

            IConfiguration Configuration = configurationBuilder.Build();

            AuthenticationHelper.Initialize(Configuration);

            var services = new ServiceCollection();

            GraphQLConfig.Config(services);
            GraphQLConfig.Input(services);
            GraphQLConfig.Type(services);
            GraphQLConfig.App(services);
            // GraphQLConfig.DataLoader(services);
            // GraphQLConfig.Auth(services);

            var serviceProvider = services.BuildServiceProvider();

            var schema = serviceProvider.GetService<ISchema>();
            var result = schema.Execute(_ =>
            {
                _.Query = @"{ floors { id name } }";
                _.Inputs = JObject.Parse("{}").ToInputs();
            });
            var json = JObject.Parse(result);

            Assert.IsTrue(true, "Should not be false");
        }
    }
}
