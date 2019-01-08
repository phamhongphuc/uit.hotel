using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.GraphQLHelper;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Helper;

namespace uit.ooad.test.Helper
{
    [TestClass]
    public class Initializer
    {
        public static ISchema Schema;
        public static IDocumentExecuter DocumentExecuter;
        public static IEnumerable<IValidationRule> ValidationRule;

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

            DocumentExecuter = serviceProvider.GetService<IDocumentExecuter>();

            ValidationRule = serviceProvider.GetService<IEnumerable<IValidationRule>>();

            InitializeDatabase.InitializeDatabaseObject();
        }
    }
}
