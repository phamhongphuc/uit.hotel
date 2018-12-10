using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._RoomKind
{
    [TestClass]
    public class _RoomKind
    {
        public _RoomKind()
        {
            RoomKindBusiness.Add(new RoomKind
            {
                Id = 1,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                PriceByDate = 1
            });
        }

        [TestMethod]
        public void RoomKinds()
        {
            SchemaHelper.Execute(
                @"/GraphQL/Service/query.services.gql",
                @"/GraphQL/Service/query.services.schema.json"
            );
        }
    }
}
