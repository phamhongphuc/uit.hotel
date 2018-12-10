using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Service
{
    [TestClass]
    public class _Service
    {
        public _Service()
        {
            ServiceBusiness.Add(new Service
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
