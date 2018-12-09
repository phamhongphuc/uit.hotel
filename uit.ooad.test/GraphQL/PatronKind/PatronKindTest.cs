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

namespace uit.ooad.test.GraphQL.PatronKind
{
    [TestClass]
    public class PatronKindTest
    {
        public PatronKindTest()
        {
            PatronKindBusiness.Add(new Models.PatronKind()
            {
                Id = 1,
                Name = "Tên loại khách hàng",
                Description = "Mô tả loại khách hàng"
            });
        }
        [TestMethod]
        public void PatronKinds()
        {
            SchemaHelper.Execute(
                @"/GraphQL/PatronKind/query.patronkinds.gql",
                @"/GraphQL/PatronKind/query.patronkinds.schema.json"
            );
        }
    }
}
