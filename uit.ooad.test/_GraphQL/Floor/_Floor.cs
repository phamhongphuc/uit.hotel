using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Floor
{
    [TestClass]
    public class _Floor
    {
        public _Floor()
        {
            FloorBusiness.Add(new Floor
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
