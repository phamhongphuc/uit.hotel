using System;
using System.IO;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using uit.ooad.GraphQLHelper;
using uit.ooad.Queries.Authentication;
using uit.ooad.Schemas;
using uit.ooad.test.Helper;
using uit.ooad.Businesses;

namespace uit.ooad.test.GraphQL.Room
{
    [TestClass]
    public class RoomTest
    {
        public RoomTest()
        {
            FloorBusiness.Add(new Models.Floor()
            {
                Id = 1,
                Name = "Tầng éc éc"
            });
            RoomKindBusiness.Add(new Models.RoomKind()
            {
                Id = 1,
                Name = "Kiểu phòng xịn ơi là xịn",
                AmountOfPeople = 4,
                NumberOfBeds = 2,
                PriceByDate = 100000
            });
            RoomBusiness.Add(new Models.Room()
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
