using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.GraphQLHelper;
using uit.ooad.Queries.Authentication;

namespace uit.ooad.test.Helper
{
    [TestClass]
    public class Initializer
    {
        public static ISchema Schema;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext TestContext)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.test.json")
               .Build();
            AuthenticationHelper.Initialize(Configuration);

            var serviceProvider = GraphQLConfig.GetServiceProvider(services =>
            {
                GraphQLConfig.Config(services);
                GraphQLConfig.Input(services);
                GraphQLConfig.Type(services);
                GraphQLConfig.App(services);

                GraphQLConfig.DataLoader(services);
                GraphQLConfig.Auth(services);
            });

            Schema = serviceProvider.GetService<ISchema>();

            TestContext.Properties.Add("schema", Schema);
        }
    }
}
