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

namespace uit.ooad.test.GraphQL.Rate
{
    [TestClass]
    public class RateTest
    {
        public RateTest()
        {
            RateBusiness.Add(new Models.Rate()
            {
                Id = 1,
                DayRate = 1,
                NightRate = 1,
                WeekRate = 1,
                MonthRate = 1,
                LateCheckOutFee = 1,
                EarlyCheckInFee = 1,
                EffectiveStartDate = DateTime.Now,
                CreateDate = DateTime.Now,
                RoomKind = RoomKindBusiness.Get(1)
            });
        }
        [TestMethod]
        public void Rates()
        {
            SchemaHelper.Execute(
                @"/GraphQL/Rate/query.rates.gql",
                @"/GraphQL/Rate/query.rates.schema.json"
            );
        }
    }
}
