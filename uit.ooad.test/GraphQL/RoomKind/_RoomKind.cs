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

namespace uit.ooad.test.GraphQL._RoomKind
{
    [TestClass]
    public class _RoomKind
    {
        public _RoomKind()
        {
            RoomKindBusiness.Add(new Models.RoomKind()
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
