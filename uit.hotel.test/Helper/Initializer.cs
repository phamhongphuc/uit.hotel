using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.GraphQLHelper;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Helper;

namespace uit.hotel.test.Helper
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

            var serviceProvider = GraphQLConfig.GetInitializedServiceProvider();

            Schema = serviceProvider.GetService<ISchema>();

            DocumentExecuter = serviceProvider.GetService<IDocumentExecuter>();

            ValidationRule = serviceProvider.GetService<IEnumerable<IValidationRule>>();

            InitializeDatabase.InitializeDatabaseObject();
        }
    }
}
