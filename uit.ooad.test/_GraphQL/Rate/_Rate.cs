using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Rate
{
    [TestClass]
    public class _Rate
    {
        public _Rate()
        {
            RoomKindBusiness.Add(new RoomKind
            {
                Id = 1,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                PriceByDate = 1
            });
            RateBusiness.Add(new Rate
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
