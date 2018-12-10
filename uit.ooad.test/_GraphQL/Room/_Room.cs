using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Room
{
    [TestClass]
    public class _Room
    {
        public _Room()
        {
            FloorBusiness.Add(new Floor
            {
                Id = 1,
                Name = "Tầng éc éc"
            });
            RoomKindBusiness.Add(new RoomKind
            {
                Id = 1,
                Name = "Kiểu phòng xịn ơi là xịn",
                AmountOfPeople = 4,
                NumberOfBeds = 2,
                PriceByDate = 100000
            });
            RoomBusiness.Add(new Room
            {
                Id = 1,
                Name = "Phòng 1",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            });
        }

        [TestMethod]
        public void Rooms()
        {
            SchemaHelper.Execute(
                @"/GraphQL/Room/query.rooms.gql",
                @"/GraphQL/Room/query.rooms.schema.json"
            );
        }
    }
}
