using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Patron
{
    [TestClass]
    public class _PatronKind
    {
        public _PatronKind()
        {
            PatronKindBusiness.Add(new PatronKind
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
